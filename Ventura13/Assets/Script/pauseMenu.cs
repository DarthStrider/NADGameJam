using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
    public EventSystem eventSystem;
    public Camera main;
    public Camera pause;
    public Canvas pauseCanvas;
    public GameObject pauseButton;
	// Use this for initialization

    void Awake()
    {
        eventSystem.gameObject.SetActive(false);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetButtonDown("Start3"))
        {
            eventSystem.gameObject.SetActive(true);

           // GameObject.FindGameObjectWithTag("player").GetComponent<CharacterMovement>().setIsLockedControls(true);
            if (main.gameObject.activeSelf)
            {
                eventSystem.SetSelectedGameObject(pauseButton);

                Time.timeScale = 0;
                main.gameObject.SetActive(false);
                pause.gameObject.SetActive(true);
                pauseCanvas.gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(pauseButton);
            }
            else if (pause.gameObject.activeSelf)
            {
                eventSystem.gameObject.SetActive(false);

               // GameObject.FindGameObjectWithTag("player").GetComponent<CharacterMovement>().setIsLockedControls(false);
                eventSystem.SetSelectedGameObject(null);
                Time.timeScale = 1;
                pause.gameObject.SetActive(false);
                main.gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(pauseButton);

            }

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
        eventSystem.gameObject.SetActive(false);

        // GameObject.FindGameObjectWithTag("player").GetComponent<CharacterMovement>().setIsLockedControls(false);
        eventSystem.SetSelectedGameObject(null);
        Time.timeScale = 1;
        pause.gameObject.SetActive(false);
        main.gameObject.SetActive(true);

        eventSystem.SetSelectedGameObject(pauseButton);

    }

    public void newGameButton()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void exitButton()
    {
        Application.Quit();
    }
}

