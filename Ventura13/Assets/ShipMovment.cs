﻿using UnityEngine;
using System.Collections;

public class ShipMovment : MonoBehaviour {

	Rigidbody2D rb;
	private float verticalMoveSpeed = 3.0f;
	private float horizontalMoveSpeed = 10.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}


	public void MoveShipHorizontal(float speed){
		rb.velocity += Vector2.right * speed * horizontalMoveSpeed;
	}


	// Update is called once per frame
	void Update () {
		rb.velocity = Vector2.up * verticalMoveSpeed;

		if(Input.GetAxis("LeftAnalogHorizontal1") < 0 || Input.GetAxis("LeftAnalogHorizontal1") > 0){
			MoveShipHorizontal (Input.GetAxis ("LeftAnalogHorizontal1"));
		}
	}
}
