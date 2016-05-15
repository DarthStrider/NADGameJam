using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
	public Vector3 travelDirection;
	public float travelDistance;
	public float speed;
	public float damperPercentage;

	private Rigidbody2D rigidbody;
	private Vector3 originalPosition;
	private Vector3 targetPosition;
	private bool travellingToTarget;

	// Use this for initialization
	void Start ()
	{
		travellingToTarget = true;
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		rigidbody.velocity = travelDirection.normalized * speed;
		originalPosition = transform.position;
		targetPosition = originalPosition + (travelDirection.normalized * travelDistance);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 toPlatform = transform.position - originalPosition;

		if (travellingToTarget)
		{
			if (toPlatform.magnitude > travelDistance)
			{
				rigidbody.velocity = -travelDirection.normalized * speed;
				travellingToTarget = false;
			}
		}
		else
		{
			float dotProduct = Vector2.Dot (travelDirection, toPlatform);
			if (dotProduct < 0)
			{
				rigidbody.velocity = travelDirection.normalized * speed;
				travellingToTarget = true;
			}
		}
	}
}