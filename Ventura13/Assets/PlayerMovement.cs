using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	public int playerNumber;
	public float moveSpeed = 4.5f;
	public float jumpSpeed = 650.0f;

	public GameObject theShip;
	public GameObject theArm;
	public GameObject theHead;
    public string[] ignoredLayers;

	private Vector3 currentShipPos;
	private Vector3 lastShipPos;
	private float xOffset;
	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private Animator anim;
	private RotateArm arm;
	private HeadBob bobSpeed;
    private float raycastInset = 0.975f;
	private float overcast = 0.02f;
    private bool isGrounded = false;
    private bool isSideColliding = false;
    private bool lockPosition = false;
    private GameObject terminalObject = null;
    private Terminal.TerminalType terminalType = Terminal.TerminalType.FREE;
	private RaycastHit2D groundHit;
	private bool onMovingPlatform;

    private bool didJump;
    private Vector2 leftAnalogInput;
    private Vector2 rightAnalogInput;
    private Vector2 triggers;

	void Start ()
    {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
		arm = theArm.GetComponent<RotateArm> ();
		bobSpeed = theHead.GetComponent<HeadBob> ();
		lastShipPos = theShip.transform.position;
        // hack that adjusts joystick number of player in case a non-existent joystick is using joystick 1
        string[] joysticks = Input.GetJoystickNames();
        if (joysticks.Length == 3 && joysticks[0] == "")
        {
            Debug.Log("empty string found as first joystick name. Why does Unity do this?");
            playerNumber += 1;
        }
	}



	// Update is called once per frame
	void Update ()
    {
        collectInput();
        if (terminalObject == null)
        {
            checkIsGrounded();
            if (Input.GetAxis("LeftAnalogHorizontal" + playerNumber) == 0)
            {
                rb.velocity += new Vector2(theShip.GetComponent<Rigidbody2D>().velocity.x, 0);
                arm.ResetArm();
                bobSpeed.increaseSpeed(.5f);
            }

            else if (Input.GetAxis("LeftAnalogHorizontal" + playerNumber) > 0)
            {
                arm.RotateTheArmLeft();
                theHead.transform.eulerAngles = new Vector3(theHead.transform.eulerAngles.x, 180.0f, theHead.transform.eulerAngles.z);
                bobSpeed.increaseSpeed(2);

            }
            else if (Input.GetAxis("LeftAnalogHorizontal" + playerNumber) < 0)
            {
                arm.RotateTheArmRight();
                theHead.transform.eulerAngles = new Vector3(theHead.transform.eulerAngles.x, 0.0f, theHead.transform.eulerAngles.z);
                bobSpeed.increaseSpeed(2);
            }
           
            string[] joys = Input.GetJoystickNames();
            foreach (string joy in joys)
            {
                //Debug.Log (joy);
            }
            if (lockPosition != true)
            {
                rb.velocity = new Vector2(((Input.GetAxis("LeftAnalogHorizontal" + playerNumber) * moveSpeed) + theShip.GetComponent<Rigidbody2D>().velocity.x), rb.velocity.y);

                if (Input.GetButtonDown("A" + playerNumber) && isGrounded)
                {
                    rb.AddForce(new Vector2(0, jumpSpeed));
                }
            }

            else
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(theShip.GetComponent<Rigidbody2D>().velocity.x, 0);
            }

            checkIsSideColliding();
            if (isSideColliding && !isGrounded)
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }
        }
        else
        {
            switch (terminalType)
            {
                case Terminal.TerminalType.STEERING:
                    steering();
                    break;
                case Terminal.TerminalType.SLOW:
                    slow();
                    break;
                case Terminal.TerminalType.GUN:
                    gun();
                    break;
                case Terminal.TerminalType.BEAM:
                    beam();
                    break;
            }
        }
		adjustToMovingPlatform ();
        didJump = false;
	}

    private void steering()
    {
        terminalObject.GetComponent<ShipMovment>().moveShip(triggers, playerNumber);
    }

    private void slow()
    {

    }

    private void gun()
    {
        terminalObject.GetComponent<GunBehaviour>().gunMovement(rightAnalogInput);
        if (triggers.y > 0)
        {
            terminalObject.GetComponent<GunBehaviour>().shoot(playerNumber);
        }
    }

    private void beam()
    {
        terminalObject.GetComponent<TractorRotation>().beamMovement(rightAnalogInput);
        terminalObject.GetComponent<TractorRotation>().tractorFireScript.fireTractor(triggers,playerNumber);
    }

	private void adjustToMovingPlatform()
	{
		if (groundHit.collider != null && groundHit.collider.gameObject.tag == "MovingPlatform")
		{
			Vector3 localVelocity = groundHit.collider.gameObject.transform.InverseTransformDirection (groundHit.collider.gameObject.GetComponent<Rigidbody2D> ().velocity);
			rb.velocity += new Vector2(localVelocity.x, localVelocity.y);
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

        //Debug.DrawLine(center + (transform.right * rayOffset));

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
				groundHit = currentHit;
            }
        }
    }

    private void collectInput()
    {
        if (Input.GetButtonDown("A" + playerNumber) && isGrounded)
        {
            didJump = true;
        }

        leftAnalogInput  = new Vector2(Input.GetAxis("LeftAnalogHorizontal" + playerNumber), (Input.GetAxis("LeftAnalogVertical" + playerNumber)));
        rightAnalogInput = new Vector2(Input.GetAxis("RightAnalogHorizontal" + playerNumber), (Input.GetAxis("RightAnalogVertical" + playerNumber)));
        triggers.x = Input.GetAxis("LT" + playerNumber);
        triggers.y = Input.GetAxis("RT" + playerNumber);
    }

    private void checkIsSideColliding()
	{
		Vector3 center = bc.bounds.center;
		float yHeight = bc.bounds.extents.y * raycastInset;
		yHeight /= 3;
		float xWidth = bc.bounds.extents.x + overcast;

		List<RaycastHit2D> raycastHits = new List<RaycastHit2D> ();
		LayerMask l = ~LayerMask.GetMask (ignoredLayers);
		raycastHits.Add(Physics2D.Raycast(center ,  Vector3.right, xWidth,l));
		raycastHits.Add(Physics2D.Raycast(center ,  -Vector3.right, xWidth,l));

		for (int i = 1; i <= 3; i++)
		{
			Vector3 newUpCenter = new Vector3 (center.x, center.y + (i * yHeight), center.z);
			raycastHits.Add(Physics2D.Raycast (newUpCenter , Vector3.right, xWidth,l));
			raycastHits.Add(Physics2D.Raycast (newUpCenter , -Vector3.right,  xWidth,l));
			Vector3 newDownCenter = new Vector3 (center.x, center.y + (-i * yHeight), center.z);
			raycastHits.Add(Physics2D.Raycast (newDownCenter ,  Vector3.right, xWidth,l));
			raycastHits.Add( Physics2D.Raycast (newDownCenter ,  -Vector3.right, xWidth,l));
		}

		isSideColliding = false;
		foreach (RaycastHit2D hit in raycastHits)
		{
			if (hit.collider != null && Vector2.Angle(hit.normal, rb.velocity.normalized) >= 90.0f)
			{
				isSideColliding = true;
			}
		}
	}

    public void setTerminalAttributes(GameObject terminalObject, Terminal.TerminalType terminalType)
    {
        this.terminalObject = terminalObject;
        this.terminalType = terminalType;
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
