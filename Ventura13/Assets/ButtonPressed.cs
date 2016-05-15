using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
    GameObject tempPlayer;
    public GameObject xButton;
    GameObject tempXButton;
    bool unlockPush = false;
    int counter = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (unlockPush == true)
        {
            if (Input.GetButton("X" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {
                tempPlayer.GetComponent<PlayerMovement>().theArm.transform.localEulerAngles = new Vector3(0, 0, -60);
                Destroy(tempXButton);
                counter = 30;
            }
        }

        if(counter > 15)
        {
            transform.Translate(transform.position.x + 0.001f, transform.position.y, transform.position.z);
            counter--;
        }
        else if(counter > 0 && counter <= 15)
        {
            transform.Translate(transform.position.x - 0.001f, transform.position.y, transform.position.z);
            counter--;
        }
        else
        {

        }



    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            tempXButton = Instantiate(xButton, new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z), Quaternion.identity) as GameObject;
            tempXButton.transform.parent = GameObject.FindGameObjectWithTag("Ship").transform;
            //tempPlayer.GetComponent<PlayerMovement>().theArm.GetComponent<RotateArm>().RotateTheArmRight();
            tempPlayer = collider.gameObject;
            unlockPush = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == tempPlayer)
        {
            Destroy(tempXButton);
            tempPlayer = null;
            unlockPush = false;
        }
    }
}
