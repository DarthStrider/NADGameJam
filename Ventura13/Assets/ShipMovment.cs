using UnityEngine;
using System.Collections;

public class ShipMovment : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 xMin;
	private Vector3 xMax;
	public BoxCollider2D box;
	public float horizontalMoveSpeed = 7.0f;
	public float maxSpeed = 5.0f;

    GameObject[] rightThrusters;
    GameObject[] leftThrusters;
    public GameObject puff;
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		xMin = Camera.main.ScreenToWorldPoint (new Vector2(0,0));
		xMax = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, 0));

	}


	public void MoveShipHorizontal(float speed){
		

	}


	// Update is called once per frame
	void Update () {
			
		if (Input.GetAxis ("LT1") > 0) {
			Debug.Log ("left trigger");
			rb.AddForce(-Vector2.right  * Input.GetAxis ("LT1") * horizontalMoveSpeed);
		} 

		 if(Input.GetAxis ("RT1") > 0) {
			Debug.Log ("right trigger");
			rb.AddForce(Vector2.right * Input.GetAxis ("RT1") * horizontalMoveSpeed);
		} 

		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}

		Vector3 extent = box.bounds.extents;
		float x = transform.position.x;
		x = Mathf.Clamp (transform.position.x, xMin.x+extent.x, xMax.x-extent.x);
		transform.position = new Vector2 (x, transform.position.y);
	}
}
