using UnityEngine;
using System.Collections;

public class RotateArm : MonoBehaviour
{
	private float currentAngle;
	private float rotationSpeed = 0.05f;

	void Start()
	{
		currentAngle = 180.0f;
	}

	void Update()
	{
		float adjustedAngle = Mathf.Lerp(transform.localEulerAngles.z, currentAngle, rotationSpeed + Time.deltaTime);
		transform.localEulerAngles = new Vector3 (0, 0, adjustedAngle);
	}

	public void RotateTheArmLeft()
	{
		currentAngle = 120.0f;
	}

	public void RotateTheArmRight()
	{
		currentAngle = 240.0f;
	}

	public void ResetArm()
	{
		currentAngle = 180.0f;
	}
}
