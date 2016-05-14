using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public int playerNumber;

	public GameObject theArm;
	public GameObject theHead;

    public string[] ignoredLayers;

	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private Animator anim;
	private RotateArm arm;
	private HeadBob bobSpeed;
    private float raycastInset = 0.95f;
	private float overcast = 0.02f;
    private bool isGrounded = false;
    private bool isSideColliding = false;
	private float moveSpeed = 4.0f;
	private float jumpSpeed = 750.0f;
    private bool lockPosition = false;

    private int hackedPlayerNumber; // adjusted because unity sometimes detects a non-existent controller as joystick 1

	void Start ()
    {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
		arm = theArm.GetComponent<RotateArm> ();
		bobSpeed = theHead.GetComponent<HeadBob> ();

        // hack that adjusts joystick number of player in case a non-existent joystick is using joystick 1
        string[] joysticks = Input.GetJoystickNames();
        if (joysticks.Length == 3 && joysticks[0] == "")
        {
            Debug.Log("empty string found as first joystick name. Why does Unity do this?");
            playerNumber += 1;
        }
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;  //IF PLAYER WILL HAVE A PARENT (PROBABLY THE SHIP) THIS NEEDS TO BE CHANGED
        }
	}

	// Update is called once per frame
	void Update ()
    {
        checkIsGrounded();
        if (isGrounded == false)
        {
            Debug.Log(isGrounded);
        }
        CheckForWallCollisions ();
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
			//Debug.Log (joy);
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

    private void checkIsGrounded()
    {
        Vector3 center     = bc.bounds.center;
        float rayOffset = bc.bounds.extents.x * raycastInset;
        float castDistance = bc.bounds.extents.y + overcast;

        Ray2D leftRay   = new Ray2D(center + (transform.right * rayOffset), -transform.up);
        Ray2D centerRay = new Ray2D(center, -transform.up);
        Ray2D rightRay  = new Ray2D(center + (-transform.right * rayOffset), -transform.up);

        int ignoredLayersMask = ~LayerMask.GetMask(ignoredLayers);

        RaycastHit2D[] hits = new RaycastHit2D[3];
        hits[0] = Physics2D.Raycast(center + (transform.right * rayOffset), -transform.up, castDistance, ignoredLayersMask);
        hits[1] = Physics2D.Raycast(center, -transform.up, castDistance, ignoredLayersMask);
        hits[2] = Physics2D.Raycast(center + (-transform.right * rayOffset), -transform.up, castDistance, ignoredLayersMask);

        isGrounded = false;
        foreach (RaycastHit2D currentHit in hits)
        {
            if (currentHit.collider != null)
            {
                isGrounded = true;
            }
        }
    }

    private void checkIsSideColliding()
    {

    }

	private void CheckForWallCollisions(){
		Vector3 center = bc.bounds.center;
		float yHeight = bc.bounds.extents.y * raycastInset;
		yHeight /= 3;

		float xWidth = bc.bounds.extents.x + overcast;

		Debug.DrawLine (center , center + (Vector3.right * xWidth), Color.blue);
		Debug.DrawLine (center , center + (-Vector3.right * xWidth), Color.blue);
		for (int i = 1; i <= 3; i++)
		{
			Vector3 newUpCenter = new Vector3 (center.x, center.y + (i * yHeight), center.z);
			Debug.DrawLine (newUpCenter , newUpCenter + (Vector3.right * xWidth), Color.blue);
			Debug.DrawLine (newUpCenter , newUpCenter + (-Vector3.right * xWidth), Color.blue);
			Vector3 newDownCenter = new Vector3 (center.x, center.y + (-i * yHeight), center.z);
			Debug.DrawLine (newDownCenter , newDownCenter + (Vector3.right * xWidth), Color.blue);
			Debug.DrawLine (newDownCenter , newDownCenter + (-Vector3.right * xWidth), Color.blue);
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
