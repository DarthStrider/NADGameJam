using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	private Rigidbody2D rb;
	private float impulseSpeed = 50.0f;
	private Vector3 bulletWorldPoint;
	private Renderer render;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		transform.Rotate (0, 0, 90);
		rb.AddForce (Vector2.up * impulseSpeed, ForceMode2D.Impulse);
		render = GetComponent<Renderer> ();
	}


	void Update(){
		if (render.isVisible == false) {
			Destroy (this.gameObject);
		}
	}
}
