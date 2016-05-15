using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
    GameObject tempPlayer;
    public GameObject xButton;
    GameObject tempXButton;
    bool unlockPush = false;
    bool useButton = true;
	public float cooldown;
	private float cooldownTimer = 0.0f;

	public static bool isSlowing = false;
	public static float slowAmount = 4.0f;

    // Use this for initialization
    void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (unlockPush == true && cooldownTimer == 0.0f)
		{
			if (Input.GetButton ("X" + tempPlayer.GetComponent<PlayerMovement> ().getPlayerNumber ()) || Input.GetKeyDown("space"))
			{
				tempPlayer.GetComponent<PlayerMovement> ().theArm.transform.localEulerAngles = new Vector3 (0, 0, -60);
				Destroy (tempXButton);
                
				transform.position = new Vector2 (transform.position.x + .2f, transform.position.y);
				useButton = false;
				StartCoroutine (popItLikeItsHawt ());

				isSlowing = true;
			}
		}
		else
		{
			cooldownTimer -= Time.deltaTime;
		}
   }
    
    IEnumerator popItLikeItsHawt()
	{
       yield return new WaitForSeconds(4.0f);
        transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
		useButton = true;
		isSlowing = false;
		cooldownTimer = cooldown;
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
