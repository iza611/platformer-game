using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class horseController : MonoBehaviour
{
    Rigidbody2D myRB;
    Animator myAnim;

    bool facingRight;
    public float maxSpeed;
   /* public AudioClip horseGallop;
    AudioSource horseAS;
    bool playedGallop = false;*/

    bool isGrounded = true;
    public float jumpHeight;
    public Transform checkGround;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public bool alive = true;
    public Image lostScreen;
    Color lostColor = new Color(1f, 1f, 1f, 1f);

    public float restartTime;
    bool restartNow = false;
    float resetTime;

    bool foundTheOwner = false;
    public Image winningScreen;
    Color winningColor = new Color(1f, 1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            isGrounded = false;
            myAnim.SetBool("isGrounded", false);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        /*if (move > 0 && !playedGallop)
        {
            horseAS.PlayOneShot(horseGallop);
            playedGallop = !playedGallop;
        }*/

        if(move > 0 && !facingRight)
        {
            flip();
        }else if(move < 0 && facingRight)
        {
            flip();
        }

        isGrounded = Physics2D.OverlapCircle(checkGround.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", isGrounded);
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
            

        if (!alive)
        {
            myRB.velocity = new Vector2(0, myRB.velocity.y);
            lostScreen.color = lostColor;
            //Destroy(gameObject);
            restartNow = true;
            resetTime = Time.time + restartTime;
            alive = !alive;
        }

        if (restartNow && resetTime <= Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (foundTheOwner)
        {
            myAnim.SetBool("canBend", foundTheOwner);
            myRB.velocity = new Vector2(0, myRB.velocity.y);
            winningScreen.color = winningColor;
        }

    }

    void flip()
    {
        if (!foundTheOwner)
        {
            facingRight = !facingRight;
            Vector3 updateScale = transform.localScale;
            updateScale.x *= -1;
            transform.localScale = updateScale;
        }
       
    }

    public void setAlive(bool isAlive)
    {
        alive = isAlive;
    }

    public void setFoundTheOwner(bool found)
    {
        foundTheOwner = found;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Owner")
        {
            ownerController owner = collision.gameObject.GetComponent<ownerController>();
            owner.setHorseHasBended(true);
        }
    }


}
