using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardController : MonoBehaviour
{
    Rigidbody2D myRB;
    Animator myAnim;

    float chaseTime;
    public float speed;
    float y;

    bool reachedLastPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        y = myRB.velocity.y;
        chaseTime = Time.time + 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //wait 3 seconds
        if (chaseTime <= Time.time)
        {
            myAnim.SetBool("seesTheHorse", true);
            myRB.velocity = new Vector2(speed, y);
        }

        if (reachedLastPlatform)
        {
            myAnim.SetBool("horseOnTheLastPlatform", true);
            myRB.velocity = new Vector2(0, y);
        }
       
    }

    public void setReachedLastPlatform(bool isWizardOnTheLastPlatform)
    {
        reachedLastPlatform = isWizardOnTheLastPlatform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Horse")
        {
            horseController horse = collision.gameObject.GetComponent<horseController>();
            horse.setAlive(false);
            myAnim.SetBool("horseInCloseArea", true);
            myRB.velocity = new Vector2(0, y);
        }
    }


}
