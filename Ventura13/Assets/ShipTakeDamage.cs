using UnityEngine;
using System.Collections;

public class ShipTakeDamage : MonoBehaviour {


	private ShipHealth healthComponent;

	void Start () {
		healthComponent = GetComponent<ShipHealth> ();
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Obstacle")
			healthComponent.TakeDamage (5);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
