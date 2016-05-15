using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    public bool first;
	private int initialSpeed;
	private int moveSpeed;
	private Rigidbody2D rb;
    public bool tractorBeamed;
	void Start () {
        first = false;
		moveSpeed = Random.Range (3, 7);
		initialSpeed = moveSpeed;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (ButtonPressed.isSlowing) {
			moveSpeed = initialSpeed - (int)ButtonPressed.slowAmount;
			moveSpeed = Mathf.Clamp (moveSpeed, 1, 7);
		}
		else 
		{
			moveSpeed = initialSpeed;
		}

        if (transform.position.y <= 0)
        {
            Destroy(this.gameObject);
        }
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
