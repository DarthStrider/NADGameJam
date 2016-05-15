using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    // Use this for initialization
    public EventSystem eventSystem;
    public GameObject[] startUps;
    public Canvas canvas;
    public GameObject credit;
    public GameObject menu;
    public GameObject startButton;
    public GameObject backButton;
    public pauseMenu pause;
    public AudioSource rocketLaunch;
    public AudioSource select;

    void Start () {
        eventSystem.SetSelectedGameObject(startButton);
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void startMenu()
    {
        Time.timeScale = 1;

        select.Play();
        canvas.gameObject.SetActive(false);
        foreach(GameObject start in startUps)
        {
            start.gameObject.SetActive(true);
        }
        pause.enabled = true;
        rocketLaunch.Play();
    }

    public void Quit()
    {
        select.Play();
        Application.Quit();
    }

    public void Credits()
    {
        select.Play();
        eventSystem.SetSelectedGameObject(backButton);
        menu.gameObject.SetActive(false);
        credit.gameObject.SetActive(true);
    }

    public void back()
    {
        select.Play();
        eventSystem.SetSelectedGameObject(startButton);
        credit.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
      

    }

}
