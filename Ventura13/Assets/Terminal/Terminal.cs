using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {
    public enum terminalType { GUN, STEERING, SLOW, GRAPPLE};
    public GameObject terminalObject;

    private GameObject tempPlayer;

    private bool lockTerminal = false;
    public bool buttonPressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(lockTerminal == true)
        {
            if (Input.GetButton("X" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {

                tempPlayer.GetComponent<PlayerMovement>().setLockPosition(true);
                

            }
            if (Input.GetButton("B" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {

                tempPlayer.GetComponent<PlayerMovement>().setLockPosition(false);
                
            }
        }
        
	}



    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {
            lockTerminal = true;
            tempPlayer = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        lockTerminal = false;
    }

    public bool GetLock()
    {
        return lockTerminal;
    }
    public void SetLock(bool sl)
    {
        lockTerminal = sl;
    }
    public GameObject GetTempPlayer()
    {
        return tempPlayer;
    }
}
