using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour {
    public EventSystem eventSystem;
    public GameObject button;
	// Use this for initialization
	void Start () {
        eventSystem.SetSelectedGameObject(button);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        SceneManager.LoadScene("Main Zack");
        Time.timeScale = 0;


    }
}
