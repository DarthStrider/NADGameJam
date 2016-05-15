using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {
    public float maxSpeed;
    float speed;
    public Vector2 speedOffest;
    float offset;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        speed = maxSpeed;
        offset = Random.Range(speedOffest.x, speedOffest.y);
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(-Vector3.up * speed);
        if (transform.position.y <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void slowDown()
    {
        speed = maxSpeed / 2;
    }

    public void speedUp()
    {
        speed = maxSpeed;
    }

 
}
