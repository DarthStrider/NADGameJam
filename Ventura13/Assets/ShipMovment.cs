using UnityEngine;
using System.Collections;

public class ShipMovment : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 xMin;
	private Vector3 xMax;
    private float leftThrusterCooldownTimer = 0;
    private float rightThrusterCooldownTimer = 0;
	public BoxCollider2D box;
	public float horizontalMoveSpeed = 7.0f;
	public float maxSpeed = 5.0f;
    public float thrusterCooldown;
	public int playerIndex; //THIS IS GOING TO BE PASSED BY THE CHARACTER CONTROLLER IN THE FUTURE

    GameObject[] rightThrusters;
    GameObject[] leftThrusters;
    public GameObject puff;
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		xMin = Camera.main.ScreenToWorldPoint (new Vector2(0,0));
		xMax = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, 0));
        rightThrusters = GameObject.FindGameObjectsWithTag("RightThruster");
        leftThrusters = GameObject.FindGameObjectsWithTag("LeftThruster");

	}


	public void MoveShipHorizontal(float speed){
		

	}


	// Update is called once per frame
	void Update () {

		Debug.Log(Input.GetAxis("LT1"));
        Debug.Log(Input.GetAxis("RT1"));
        if (Input.GetAxis ("RT1") > 0) {
			//Debug.Log ("left trigger");
			rb.AddForce(-Vector2.right  * Input.GetAxis ("RT1") * horizontalMoveSpeed, ForceMode2D.Impulse);

            if (rightThrusterCooldownTimer <= 0)
            {
                Debug.Log("firing thrusters");
                foreach (GameObject thruster in rightThrusters)
                {
                    Instantiate(puff, thruster.transform.position + thruster.transform.right * 0.8f, Quaternion.Euler(0, 0, thruster.transform.eulerAngles.z - 90f));
                }
                rightThrusterCooldownTimer = thrusterCooldown;
				this.GetComponent<x360_Gamepad>().AddRumble(playerIndex-1,0.2f, new Vector2(5.0f, 5.0f));
            }
            else if (rightThrusterCooldownTimer > 0)
            {
                rightThrusterCooldownTimer -= Time.deltaTime;
            }

        } 

		 if(Input.GetAxis ("LT1") > 0) {
			rb.AddForce(Vector2.right * Input.GetAxis ("LT1") * horizontalMoveSpeed, ForceMode2D.Impulse);

            if (leftThrusterCooldownTimer <= 0)
            {
                Debug.Log("firing thrusters");
                foreach (GameObject thruster in leftThrusters)
                {
                    Instantiate(puff, thruster.transform.position + thruster.transform.right*0.8f, Quaternion.Euler(0,0,thruster.transform.eulerAngles.z-90f));
                }
                leftThrusterCooldownTimer = thrusterCooldown;
				this.GetComponent<x360_Gamepad>().AddRumble(playerIndex-1,0.2f, new Vector2(5.0f, 5.0f));
            }
            else if (leftThrusterCooldownTimer > 0)
            {
                leftThrusterCooldownTimer -= Time.deltaTime;
            }

        } 

		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}

		Vector3 extent = box.bounds.extents;
		float x = transform.position.x;
		x = Mathf.Clamp (transform.position.x, xMin.x+extent.x, xMax.x-extent.x);
		transform.position = new Vector2 (x, transform.position.y);

		if (transform.position.x <= xMin.x + extent.x && rb.velocity.x < 0.0f) {
			rb.velocity = new Vector2 (0, 0);
		}

		if (transform.position.x >= xMax.x-extent.x && rb.velocity.x > 0.0f) {
			rb.velocity = new Vector2 (0, 0);
		}

	}


}
