using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int playerNumber;

	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private float overcast = 0.1f;
	private float moveSpeed = 4.0f;
	private float jumpSpeed = 750.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
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
	
		rb.velocity = new Vector2 (Input.GetAxis ("LeftAnalogHorizontal" + playerNumber) * moveSpeed, rb.velocity.y);

		string[] joys = Input.GetJoystickNames (); 
		foreach (string joy in joys) {
			Debug.Log (joy);
		}

		Debug.Log (bc.bounds.extents.y);
		Debug.DrawLine (bc.bounds.center, new Vector3 (bc.bounds.center.x, (bc.bounds.center.y - (bc.bounds.extents.y + overcast)), bc.bounds.center.z));

		if (Input.GetButtonDown ("A" + playerNumber)) {
			rb.AddForce (new Vector2(0, jumpSpeed));
		}
	}
}
