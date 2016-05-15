using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformPlayerUpdate : MonoBehaviour
{
	private List<GameObject> players = new List<GameObject>();
	private Rigidbody2D rigidbody;
	private Vector3 positionLastFrame;

	// Use this for initialization
	void Start ()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		positionLastFrame = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 currentPosition = transform.position;
		foreach (GameObject player in players)
		{
			//player.GetComponent<Rigidbody2D> ().velocity += rigidbody.velocity;
			player.transform.position += currentPosition - positionLastFrame;
		}
		positionLastFrame = currentPosition;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			players.Add(collision.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			players.Remove(collision.gameObject);
		}
	}
}