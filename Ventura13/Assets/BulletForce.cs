using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	private Rigidbody2D rb;
	private float impulseSpeed = 25;
	private Vector3 bulletWorldPoint;
	private Renderer render;
    public float BulletDamage = 70;
   
    
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

    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Tag" + col.gameObject.name);
        if(col.gameObject.tag == "Obstacle")
        {
            col.gameObject.GetComponent<ObstacleHealth>().Health -= BulletDamage;
        }
    }
    void onCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit by " + col.gameObject.name);

    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
           
            Destroy(this.gameObject, .2f);
        }
    }
}
