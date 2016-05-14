using UnityEngine;
using System.Collections;

public class ShipMovment : MonoBehaviour {

	Rigidbody2D rb;
	private float verticalMoveSpeed = 5.0f;
	private float horizontalMoveSpeed = 10.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}


	public void MoveShipHorizontal(float speed){
		rb.velocity += Vector2.right * speed * horizontalMoveSpeed;
	}


	// Update is called once per frame
	void Update () {
		rb.velocity = Vector2.up * verticalMoveSpeed;

		if(Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0){
			MoveShipHorizontal (Input.GetAxis ("Horizontal"));
		}
	}
}
