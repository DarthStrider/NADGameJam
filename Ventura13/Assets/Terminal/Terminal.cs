using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {
    public enum TerminalType { GUN, STEERING, SLOW, BEAM};
    public TerminalType terminalType;
    public GameObject terminalObject;

    public GameObject xButton;
    public GameObject bButton;
    int bCount = 0;
    private GameObject tempXButton;
    private GameObject tempBButton;

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
				tempPlayer.GetComponent<SwapSprites> ().SwapFace ();
                
                Destroy(tempXButton);

                if (bCount == 0)
                {
                    tempBButton = Instantiate(bButton, new Vector3(transform.position.x, (transform.position.y + 1.25f), transform.position.z), Quaternion.identity) as GameObject;
                    bCount++;
                    
                }


            }
            if (Input.GetButton("B" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {
                Destroy(tempBButton);
                bCount = 0;
                tempPlayer.GetComponent<PlayerMovement>().setLockPosition(false);
				tempPlayer.GetComponent<SwapSprites> ().SwapSide ();
                
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
            tempXButton = Instantiate(xButton, new Vector3(transform.position.x, (transform.position.y + 1.25f), transform.position.z), Quaternion.identity) as GameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (tempXButton != null)
        {
            Destroy(tempXButton);
        }
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
