using UnityEngine;
using System.Collections;

public class TractorRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float leftWorldAngle;
    public float rightWorldAngle;
    public tractorBehaviour tractorFireScript;
    public float startAngle;
    float rotationScalar;
    public float scalar;
    // Use this for initialization
    void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, startAngle));
    }

    // Update is called once per frame
    void Update()
    {
        if (tractorFireScript.pressed)
        {
            rotationScalar = scalar;
        }
        else
        {
            rotationScalar = 1;
        }
    }
    public void beamMovement(Vector2 input)
    {
        if (input.x != 0 || input.y != 0)
        {
            float angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;

			Debug.Log (angle);

            if (leftWorldAngle == -135.0f && rightWorldAngle == 45.0f)  // left gun
            {
                if (angle < 45 && angle > -135)
                {
                    angle = 135 - angle;
                }
                else if (angle >= 45 && angle <= 135)
                {
                    angle = 90;
                }
                else if (angle <= -135 || angle > 135)
                {
                    angle = 270;
                }
            }
            else if (leftWorldAngle == -45.0f && rightWorldAngle == 135.0f) // right gun
            {
                if (angle > -45 && angle < 135)
                {
                    angle = 225.0f - angle;
                }
                else if (angle >= -135 && angle <= -45)
                {
                    angle = 270;
                }
                else if (angle < -135 || angle >= 135)
                {
                    angle = 90;
                }
			}
			else if (leftWorldAngle == -155 && rightWorldAngle == 10) // right tractor
			{
				if (angle > -155 && angle <= 0)
				{
					angle = 135 - angle;
				}
				else if (angle > 0 && angle < 10)
				{
					angle = 135 - angle;
				}
				else if (angle > 10 && angle <= 95)
				{
					angle = 125;
				}
				else if (angle > 95 && angle <= 180)
				{
					angle = 290;
				}
				else if (angle <= -155)
				{
					angle = 290;
				}
			}
			else if (leftWorldAngle == -10 && rightWorldAngle == 155) // left tractor
			{
				if (angle >= 0 && angle < 155)
				{
					angle = 225 - angle;
				}
				else if (angle < 0 && angle >= -10)
				{
					angle = 225 - angle;
				}
				else if (angle < -10 && angle >= -95)
				{
					angle = 235;
				}
				else if (angle < -95 && angle > -180)
				{
					angle = 70;
				}
				else if (angle >= 155)
				{
					angle = 70;
				}
			}

			Debug.Log (angle);

            angle = Mathf.Lerp(transform.localRotation.eulerAngles.z, angle, (rotationSpeed *rotationScalar * Time.deltaTime));
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

}