using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
	List<GameObject> players = new List<GameObject>();
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start ()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject player in players)
		{
			player.GetComponent<Rigidbody2D> ().velocity += rigidbody.velocity;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("collision enter!");
		if (collision.gameObject.tag == "Player")
		{
			players.Add(collision.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log ("collision exit!");
		if (collision.gameObject.tag == "Player")
		{
			players.Remove(collision.gameObject);
		}
	}
}
