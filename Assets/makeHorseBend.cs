using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeHorseBend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Horse")
        {
            horseController horse = collision.gameObject.GetComponent<horseController>();
            horse.setFoundTheOwner(true);

            touchTheHorse owner = collision.gameObject.GetComponent<touchTheHorse>();
            owner.setHorseHasBended(true);
        }
    }
}
