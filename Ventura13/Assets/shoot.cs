using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bullet;
	public float cooldownTime = .2f;
	private float cooldownTimer = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("RT1") > 0 && cooldownTimer <= 0)
		{
			Instantiate (bullet, bulletSpawn.position, Quaternion.identity);
            bullet.GetComponent<BulletForce>().parentShooter = bulletSpawn;
			cooldownTimer = cooldownTime;
            this.GetComponent<x360_Gamepad>().AddRumble(0,0.5f, new Vector2(10.0f, 10.0f));
		}
		else
		{
			cooldownTimer -= Time.deltaTime;
		}
	}
}
