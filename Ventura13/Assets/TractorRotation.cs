using UnityEngine;
using System.Collections;

public class TractorRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float leftWorldAngle;
    public float rightWorldAngle;
    public tractorBehaviour tractorFireScript;
    public float startAngle;

    // Use this for initialization
    void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, startAngle));
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void beamMovement(Vector2 input)
    {
        if (input.x != 0 || input.y != 0)
        {
            float angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
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
            angle = Mathf.Lerp(transform.localRotation.eulerAngles.z, angle, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

}