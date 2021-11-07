using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardController : MonoBehaviour
{
    Rigidbody2D myRB;
    Animator myAnim;

    bool facingRight;
    public float maxSpeed;

    public bool horseInCloseArea = false;

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
        
    }

    void FixedUpdate()
    {
        if (horseInCloseArea)
        {
            myAnim.SetBool("seesTheHorse", horseInCloseArea);

            myRB.velocity = new Vector2(1 * maxSpeed, myRB.velocity.y);
        }

        if (!horseInCloseArea)
        {
            myAnim.SetBool("seesTheHorse", horseInCloseArea);

            myRB.velocity = new Vector2(0 * maxSpeed, myRB.velocity.y);
        }
       
    }

    public void setHorseInCloseArea(bool isHorse)
    {
        horseInCloseArea = isHorse;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Horse")
        {
            horseInCloseArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Horse")
        {
            horseInCloseArea = true;
        }
    }

}
