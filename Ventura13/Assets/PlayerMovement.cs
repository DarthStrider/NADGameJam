using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int playerNumber;


	public GameObject theArm;
	public GameObject theHead;


	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private Animator anim;
	private RotateArm arm;
	private HeadBob bobSpeed;
	private float overcast = 0.1f;
	private float moveSpeed = 4.0f;
	private float jumpSpeed = 750.0f;
    private bool lockPosition = false;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
		arm = theArm.GetComponent<RotateArm> ();
		bobSpeed = theHead.GetComponent<HeadBob> ();

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")
			transform.parent = other.transform;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")
			transform.parent = null;  //IF PLAYER WILL HAVE A PARENT (PROBABLY THE SHIP) THIS NEEDS TO BE CHANGED
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("LeftAnalogHorizontal" + playerNumber) > 0)
		{
			arm.RotateTheArmLeft ();
			theHead.transform.eulerAngles = new Vector3(theHead.transform.eulerAngles.x, 180.0f, theHead.transform.eulerAngles.z);
			bobSpeed.increaseSpeed (2);

		}
		else if	(Input.GetAxis ("LeftAnalogHorizontal" + playerNumber) < 0)
		{
			arm.RotateTheArmRight ();
			theHead.transform.eulerAngles = new Vector3(theHead.transform.eulerAngles.x, 0.0f, theHead.transform.eulerAngles.z);
			bobSpeed.increaseSpeed (2);
		}

		if (Input.GetAxis ("LeftAnalogHorizontal" + playerNumber) == 0)
		{
			arm.ResetArm ();
			bobSpeed.increaseSpeed (.5f);
		}

		string[] joys = Input.GetJoystickNames (); 
		foreach (string joy in joys) {
			Debug.Log (joy);
		}
        if (lockPosition != true)
        {
            rb.velocity = new Vector2(Input.GetAxis("LeftAnalogHorizontal" + playerNumber) * moveSpeed, rb.velocity.y);

            //Debug.DrawLine(bc.bounds.center, new Vector3(bc.bounds.center.x, (bc.bounds.center.y - (bc.bounds.extents.y + overcast)), bc.bounds.center.z));

            if (Input.GetButtonDown("A" + playerNumber))
            {
                rb.AddForce(new Vector2(0, jumpSpeed));
            }
        }
	}


    public int getPlayerNumber()
    {
        return playerNumber;
    }
    public bool getLock()
    {
        return lockPosition;
    }
    public void setLockPosition(bool lp)
    {
        lockPosition = lp;
    }

}
