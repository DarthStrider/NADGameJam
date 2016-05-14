using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    // Use this for initialization
    public EventSystem eventSystem;


    void Awake()
    {
        eventSystem.gameObject.SetActive(true);

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startMenu()
    {
        eventSystem.gameObject.SetActive(false);
        Application.LoadLevel("layout");
    }

}
