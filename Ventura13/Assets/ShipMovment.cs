using UnityEngine;
using System.Collections;

public class ShipMovment : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 xMin;
	private Vector3 xMax;
	public BoxCollider2D box;
	private float horizontalMoveSpeed = 2.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		xMin = Camera.main.ScreenToWorldPoint (new Vector2(0,0));
		xMax = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, 0));

	}


	public void MoveShipHorizontal(float speed){
		rb.velocity = new Vector2 (speed * horizontalMoveSpeed, rb.velocity.y);
	}


	// Update is called once per frame
	void Update () {
		
		Debug.Log (xMax.x);
			
		if (Input.GetAxis ("LeftAnalogHorizontal1") < 0 || Input.GetAxis ("LeftAnalogHorizontal1") > 0) {
			MoveShipHorizontal (Input.GetAxis ("LeftAnalogHorizontal1"));
		} else {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}
		Vector3 extent = box.bounds.extents;
		float x = transform.position.x;
		x = Mathf.Clamp (transform.position.x, xMin.x+extent.x, xMax.x-extent.x);
		transform.position = new Vector2 (x, transform.position.y);
	}
}
