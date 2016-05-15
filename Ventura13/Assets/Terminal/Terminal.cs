using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {
    public enum TerminalType { GUN, STEERING, SLOW, BEAM, FREE};
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
                tempPlayer.GetComponent<PlayerMovement>().setTerminalAttributes(terminalObject, terminalType);

                Destroy(tempXButton);

                if (bCount == 0)
                {
                    tempBButton = Instantiate(bButton, new Vector3(transform.position.x, (transform.position.y + 1.25f), transform.position.z), Quaternion.identity) as GameObject;
                    tempBButton.transform.parent = GameObject.FindGameObjectWithTag("Ship").transform;
                    bCount++;
                    
                }


            }
            if (Input.GetButton("B" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {
                Destroy(tempBButton);
                bCount = 0;
                tempPlayer.GetComponent<PlayerMovement>().setLockPosition(false);
                tempPlayer.GetComponent<PlayerMovement>().setTerminalAttributes(null, TerminalType.FREE);
                tempPlayer.GetComponent<SwapSprites> ().SwapSide ();
                
            }
        }
        
	}



    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player" && !lockTerminal)
        {
            lockTerminal = true;
            
            tempPlayer = collider.gameObject;
            tempXButton = Instantiate(xButton, new Vector3(transform.position.x, (transform.position.y + 1.25f), transform.position.z), Quaternion.identity) as GameObject;
            tempXButton.transform.parent = GameObject.FindGameObjectWithTag("Ship").transform;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber() == collider.GetComponent<PlayerMovement>().getPlayerNumber())
        {
            if (tempXButton != null)
            {
                Destroy(tempXButton);
            }
            lockTerminal = false;
        }
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
