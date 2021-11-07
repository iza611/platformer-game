using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killTheWizard : MonoBehaviour
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
        if (collision.tag == "Wizard")
        {
            wizardController wizard = collision.gameObject.GetComponent<wizardController>();
            wizard.setReachedLastPlatform(true);
        }
    }
}
