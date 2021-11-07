using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownerController : MonoBehaviour
{
    Animator myAnim;
    bool horseHasBended;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (horseHasBended)
        {
            myAnim.SetBool("horseIsBending", true);
        }

    }

    public void setHorseHasBended(bool bended)
    {
        horseHasBended = bended;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Horse")
        {
            horseController horse = collision.gameObject.GetComponent<horseController>();
            horse.setFoundTheOwner(true);
        }
    }

}
