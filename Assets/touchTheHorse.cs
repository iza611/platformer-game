using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchTheHorse : MonoBehaviour
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
            myAnim.SetBool("horseIsBending", horseHasBended);
        }
        
    }

    public void setHorseHasBended(bool bended)
    {
        horseHasBended = true;
    }

}
