using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	private float health = 50;

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
			Destroy (this.gameObject);
		}
	}
}
