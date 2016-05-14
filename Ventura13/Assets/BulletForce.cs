using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	private Rigidbody2D rb;
	private float impulseSpeed = 50.0f;
	private Vector3 bulletWorldPoint;
	private Renderer render;
    public Transform parentShooter;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        transform.rotation = parentShooter.transform.rotation;
		rb.AddForce ( parentShooter.right * impulseSpeed, ForceMode2D.Impulse);
		render = GetComponent<Renderer> ();
	}


	void Update(){
		if (render.isVisible == false) {
			Destroy (this.gameObject);
		}
	}
}
