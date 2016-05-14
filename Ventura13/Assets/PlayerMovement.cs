using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private float overcast = 0.1f;
	private float moveSpeed = 4.0f;
	private float jumpSpeed = 750.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * moveSpeed, rb.velocity.y);

		Debug.Log (bc.bounds.extents.y);
		Debug.DrawLine (bc.bounds.center, new Vector3 (bc.bounds.center.x, (bc.bounds.center.y - (bc.bounds.extents.y + overcast)), bc.bounds.center.z));

		if (Input.GetButtonDown ("Jump")) {
			rb.AddForce (new Vector2(0, jumpSpeed));
		}
	}
}
