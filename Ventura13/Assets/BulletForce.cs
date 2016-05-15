using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	private Rigidbody2D rb;
	private float impulseSpeed = 50.0f;
	private Vector3 bulletWorldPoint;
	private Renderer render;
    public Transform parentShooter;
   

	void Start () {
        render = GetComponent<Renderer>();
		rb = GetComponent<Rigidbody2D> ();
         transform.rotation = parentShooter.transform.rotation;
        transform.Rotate(Vector3.forward * 90);
		rb.AddForce ( parentShooter.up * impulseSpeed, ForceMode2D.Impulse);
		
	}


	void Update(){
		if (render.isVisible == false) {
			Destroy (this.gameObject);
		}
	}
}
