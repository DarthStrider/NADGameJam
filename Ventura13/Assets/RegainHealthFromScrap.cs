using UnityEngine;
using System.Collections;

public class RegainHealthFromScrap : MonoBehaviour {

	private ShipHealth healthComponent;

	void Start () {
		healthComponent = GetComponent<ShipHealth> ();
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Scrap")
			healthComponent.healDamage (5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
