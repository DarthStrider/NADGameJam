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
	public float maxSpeed = 3.0f;
    public float boostThreshold = 1.0f;
    public float boost = 2.5f;
    public float thrusterCooldown;
    public AudioSource thursters;
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
        Vector3 extent = box.bounds.extents;
        float x = transform.position.x;
        x = Mathf.Clamp(transform.position.x, xMin.x + extent.x, xMax.x - extent.x);
        transform.position = new Vector2(x, transform.position.y);

        if (transform.position.x <= xMin.x + extent.x + 0.001f && rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (transform.position.x >= xMax.x - extent.x - 0.001f && rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void moveShip(Vector2 input, int player)
    {
        if (input.y > 0 && input.x <= 0)
        {
            Vector2 direction = new Vector2(-1,0);
            if (Vector2.Dot(rb.velocity, direction) < 0)
            {
                horizontalMoveSpeed = 3500.0f;
            }
            else if (rb.velocity.magnitude < boostThreshold)
            {
                horizontalMoveSpeed = 1500.0f * boost;
            }
            else
            {
                horizontalMoveSpeed = 1500.0f;
            }

            rb.AddForce(-Vector2.right * input.y * horizontalMoveSpeed, ForceMode2D.Impulse);
        }

        if (input.x > 0 && input.y <= 0)
        {
            Vector2 direction = new Vector2(1, 0);
            if (Vector2.Dot(rb.velocity, direction) < 0)
            {
                horizontalMoveSpeed = 3500.0f;
            }
            else if (rb.velocity.magnitude < boostThreshold)
            {
                horizontalMoveSpeed = 1500.0f * boost;
            }
            else
            {
                horizontalMoveSpeed = 1500.0f;
            }

            Debug.Log(horizontalMoveSpeed);

            rb.AddForce(Vector2.right * input.x * horizontalMoveSpeed, ForceMode2D.Impulse);
        }

        // puff the magic dragon
        if (input.y > 0)
        {
            if (rightThrusterCooldownTimer <= 0)
            {
                thursters.Play();

                int i = 0;
                foreach (GameObject thruster in rightThrusters)
                {
                    Instantiate(puff, thruster.transform.position + thruster.transform.right * 0.8f, Quaternion.Euler(0, 0, thruster.transform.eulerAngles.z - 90f));
                    ++i;
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
            if (leftThrusterCooldownTimer <= 0)
            {
                thursters.Play();

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
    }
}
