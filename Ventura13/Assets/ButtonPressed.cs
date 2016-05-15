using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
    GameObject tempPlayer;
    public GameObject xButton;
    GameObject tempXButton;
    bool unlockPush = false;
    bool useButton = true;
    public AudioSource slowMo;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (unlockPush == true)
        {
            if (Input.GetButton("X" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {
                slowMo.Play();
                tempPlayer.GetComponent<PlayerMovement>().theArm.transform.localEulerAngles = new Vector3(0, 0, -60);
                Destroy(tempXButton);
                
                transform.position = new Vector2(transform.position.x + .2f, transform.position.y);
                useButton = false;
                StartCoroutine(popItLikeItsHawt());
            }
        }

 
        
   }
    
    IEnumerator popItLikeItsHawt()
    {

       yield return new WaitForSeconds(4.5f);
        transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
        useButton = true;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && useButton)
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
