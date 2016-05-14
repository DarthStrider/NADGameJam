using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

	private int moveSpeed;
	private Rigidbody2D rb;

	void Start () {
		moveSpeed = Random.Range (3, 7);
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = (Vector2.down * moveSpeed);
	}
}
