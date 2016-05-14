using UnityEngine;
using System.Collections;

public class DebrisExplosion : MonoBehaviour {

    private float randX;
    private float randY;
    private Vector2 direction;
    private float force;
    private Rigidbody2D rb;

	void Start () {
        
        randX = Random.Range(0, 361);
        randY = Random.Range(0, 361);
        direction = new Vector2(randX, randY);
        rb = GetComponent<Rigidbody2D>();

        force = Random.Range(3, 7);
        rb.AddForce(direction * force);

    }
	
}
