using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyController : MonoBehaviour
{
    public int sceneId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();
        if (Input.GetKey("space")) SceneManager.LoadScene(sceneId);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
