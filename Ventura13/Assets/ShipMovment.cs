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

	// Update is called once per frame
	void Update ()
    {
        if(transform.position.x < -18.5f)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(-18.5f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > 18.5f)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(18.5f, transform.position.y, transform.position.z);
        }
    
	}

    public void moveShip(Vector2 input, int player)
    {
        if (input.y > 0)
        {
            //Debug.Log ("left trigger");
            rb.AddForce(-Vector2.right * input.y * horizontalMoveSpeed, ForceMode2D.Impulse);

            if (rightThrusterCooldownTimer <= 0)
            {
                foreach (GameObject thruster in rightThrusters)
                {
                    Instantiate(puff, thruster.transform.position + thruster.transform.right * 0.8f, Quaternion.Euler(0, 0, thruster.transform.eulerAngles.z - 90f));
                }
                rightThrusterCooldownTimer = thrusterCooldown;
                this.GetComponent<x360_Gamepad>().AddRumble(player - 1, 0.2f, new Vector2(5.0f, 5.0f));
            }
            else if (rightThrusterCooldownTimer > 0)
            {
                rightThrusterCooldownTimer -= Time.deltaTime;
            }
        }

        if (input.x > 0)
        {
            rb.AddForce(Vector2.right * input.x * horizontalMoveSpeed, ForceMode2D.Impulse);

            if (leftThrusterCooldownTimer <= 0)
            {
                foreach (GameObject thruster in leftThrusters)
                {
                    Instantiate(puff, thruster.transform.position + thruster.transform.right * 0.8f, Quaternion.Euler(0, 0, thruster.transform.eulerAngles.z - 90f));
                }
                leftThrusterCooldownTimer = thrusterCooldown;
                this.GetComponent<x360_Gamepad>().AddRumble(player - 1, 0.2f, new Vector2(5.0f, 5.0f));
            }
            else if (leftThrusterCooldownTimer > 0)
            {
                leftThrusterCooldownTimer -= Time.deltaTime;
            }
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        Vector3 extent = box.bounds.extents;
        float x = transform.position.x;
        x = Mathf.Clamp(transform.position.x, xMin.x + extent.x, xMax.x - extent.x);
        transform.position = new Vector2(x, transform.position.y);

        if (transform.position.x <= xMin.x + extent.x)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (transform.position.x >= xMax.x - extent.x)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
