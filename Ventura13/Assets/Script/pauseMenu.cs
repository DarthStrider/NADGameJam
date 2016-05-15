using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
    public EventSystem eventSystem;
    public Canvas pauseCanvas;
	// Use this for initialization

    void Awake()
    {
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetButtonDown("Start3"))
        {

                Time.timeScale = 0;
                pauseCanvas.gameObject.SetActive(true);
                //eventSystem.SetSelectedGameObject(pauseButton);
   
        }

        if (Input.GetButtonDown("Start1"))
        {
            Debug.Log("player1");
        }
        if (Input.GetButtonDown("Start2")) { 

            Debug.Log("player2");
    }
        if (Input.GetButtonDown("Start3"))
        {
        Debug.Log("player3");
        }
        }

    public void continueButton()
    {
        pauseCanvas.gameObject.SetActive(false);
       
        Time.timeScale = 1;

    }

  

    public void exitButton()
    {
        Application.Quit();
    }
}

