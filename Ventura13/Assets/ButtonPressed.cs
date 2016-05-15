using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
    GameObject tempPlayer;
    public GameObject xButton;
    GameObject tempXButton;
    bool unlockPush = false;
    public float animationSpeed;
    public float animationDepth;
    public float cooldownTimer = 0;
    public float coolDownTime = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float animationTimer = 0;

        Debug.Log(transform.position + "    " + (transform.position + (transform.right * animationDepth)));
        if (unlockPush == true)
        {
            if (Input.GetButton("X" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {
                tempPlayer.GetComponent<PlayerMovement>().theArm.transform.localEulerAngles = new Vector3(0, 0, -60);
                Destroy(tempXButton);
                
                animationTimer = 0.15f;
            }
        }

 
        //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + animationDepth, transform.position.y), animationSpeed);
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
