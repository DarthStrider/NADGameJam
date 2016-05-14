using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour
{
    public float rotationSpeed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GunMovement(Vector2.zero);
    }
    public void GunMovement(Vector2 input)
    {
        //Debug.Log(Input.GetJoystickNames().Length);
        float joyX = Input.GetAxis("RightAnalogHorizontal1");
        float joyY = Input.GetAxis("RightAnalogVertical1");
        if (joyX != 0 || joyY != 0)
        {
            //Debug.Log("JoyX: " + joyX);
            //Debug.Log("JoyY: " + joyY);

            float angle             = Mathf.Atan2(joyX, joyY) * Mathf.Rad2Deg;
            float adjustedAngle     = (angle < 0.0f) ? Mathf.Abs(angle) : (360.0f - angle);
            adjustedAngle           = Mathf.Clamp(adjustedAngle, 90.0f, 270.0f);
            adjustedAngle           = Mathf.Lerp(transform.localRotation.eulerAngles.z, adjustedAngle, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, adjustedAngle));
        }
    }

}
