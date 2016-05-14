using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	private float health = 50;
    public GameObject explotionAnimation;

	void Start () {
	
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Bullet") {
			health -= 5;
			Destroy (other.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		if (health <= 0) {
            Instantiate(explotionAnimation, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
