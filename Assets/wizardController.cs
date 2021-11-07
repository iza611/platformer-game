using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardController : MonoBehaviour
{
    Rigidbody2D myRB;
    Animator myAnim;

    public float speed;

    public bool horseInCloseArea = false;

    float y;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        y = myRB.velocity.y;

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

            myRB.velocity = new Vector2(1 * speed, y);
        }

        if (!horseInCloseArea)
        {
            myAnim.SetBool("seesTheHorse", horseInCloseArea);

            myRB.velocity = new Vector2(0 * speed, y);
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
