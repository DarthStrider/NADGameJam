using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    public bool first;
	private int moveSpeed;
	private Rigidbody2D rb;
    public bool tractorBeamed;
	void Start () {
        first = false;
		moveSpeed = Random.Range (3, 7);
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (tractorBeamed == false)
        {
            rb.velocity = (Vector2.down * moveSpeed);
        }
        if (tractorBeamed == true)
        {
            if (first == false)
            {
                rb.velocity = Vector2.zero;
                first = true;
            }
        }
	}



}
