using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	private float totalHealth = 50;
	private float currentHealth;
    public GameObject explotionAnimation;

	void Start () {
		currentHealth = totalHealth;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Bullet") {
			currentHealth -= 5;
			Destroy (other.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
            Instantiate(explotionAnimation, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

		if (totalHealth / currentHealth < .66f && totalHealth / currentHealth > .33f) {
			//change apperance
		}

		if (totalHealth / currentHealth < .33f && totalHealth / currentHealth > .1f) {
			//change apperance
		}
    }
}
