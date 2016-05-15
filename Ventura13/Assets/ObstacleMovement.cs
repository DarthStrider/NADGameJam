using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    public bool first;
	private int moveSpeed;
	private int initialSpeed;
	private Rigidbody2D rb;
    public bool tractorBeamed;
    ObstacleHealth.ObstacleType obType;
	void Start () {
        first = false;
		moveSpeed = Random.Range (3, 7);
		initialSpeed = moveSpeed;
		rb = GetComponent<Rigidbody2D> ();
        obType = gameObject.GetComponent<ObstacleHealth>().obsType;
	}

    // Update is called once per frame
    void Update() {

		if (ButtonPressed.isSlowing) {
			moveSpeed = initialSpeed - (int)ButtonPressed.slowAmount;
			moveSpeed = Mathf.Clamp (moveSpeed, 1, 7);
		}
		else 
		{
			moveSpeed = initialSpeed;
		}



        switch (obType) {
            case ObstacleHealth.ObstacleType.AST:
            if (transform.position.y <= -40)
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
                break;

            case ObstacleHealth.ObstacleType.SAT:
                break;
            case ObstacleHealth.ObstacleType.BLI:
                if (transform.position.y <= -40)
                {
                    Destroy(this.gameObject);
                }
                if (tractorBeamed == false)
                {
                    rb.velocity = (Vector2.down * moveSpeed*.9f);
                   
                }
                if (tractorBeamed == true)
                {
                    if (first == false)
                    {
                        rb.velocity = Vector2.zero;
                        first = true;
                    }
                }
                break;
        }

        
	}



}
