using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	private Rigidbody2D rb;
	private float impulseSpeed = 50.0f;
	private Vector3 bulletWorldPoint;
	private Renderer render;
   
    
    public void Initalize(Transform gunTip)
    {
        render = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(gunTip.up * impulseSpeed, ForceMode2D.Impulse);
        transform.rotation = gunTip.rotation;
        transform.Rotate(Vector3.forward * 90);
       
    }
    

    

	void Update(){
		if (render.isVisible == false) {
			Destroy (this.gameObject);
		}
	}
}
