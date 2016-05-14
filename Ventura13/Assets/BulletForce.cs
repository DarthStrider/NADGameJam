using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	private Rigidbody2D rb;
	private float impulseSpeed = 50.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		transform.Rotate (0, 0, 90);
		rb.AddForce (Vector2.up * impulseSpeed, ForceMode2D.Impulse);
	}
	
}
