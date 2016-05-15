using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    public bool first;
	private int moveSpeed;
	private Rigidbody2D rb;
    public bool tractorBeamed;
    ObstacleHealth.ObstacleType obType;
	void Start () {
        first = false;
		moveSpeed = Random.Range (3, 7);
		rb = GetComponent<Rigidbody2D> ();
        obType = gameObject.GetComponent<ObstacleHealth>().obsType;
	}

    // Update is called once per frame
    void Update() {

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
                break;
        }

        
	}



}
