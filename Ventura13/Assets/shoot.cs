using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bullet;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			Instantiate (bullet, bulletSpawn.position, Quaternion.identity);
		}
	}
}
