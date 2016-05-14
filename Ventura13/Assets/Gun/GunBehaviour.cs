using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    public float leftWorldAngle;
    public float rightWorldAngle;
    public GameObject gunPodSprite;


    // Use this for initialization
    void Start()
    {
        
 /*
        if (leftWorldAngle == -135.0f && rightWorldAngle == 45.0f)  // left gun
        {
            gunPodSprite.transform.localRotation = Quaternion.Euler(new Vector3(gunPodSprite.transform.rotation.eulerAngles.x, gunPodSprite.transform.rotation.eulerAngles.y, 180.0f));
        }
        else if (leftWorldAngle == -45.0f && rightWorldAngle == 135.0f) // right gun
        {
            gunPodSprite.transform.localRotation = Quaternion.Euler(new Vector3(gunPodSprite.transform.rotation.eulerAngles.x, gunPodSprite.transform.rotation.eulerAngles.y, 180.0f));
        }
 */
    }

    // Update is called once per frame
    void Update()
    {
        //GunMovement(Vector2.zero);
    }
    public void GunMovement(Vector2 input)
    {
        //Debug.Log(Input.GetJoystickNames().Length);
        float joyX = Input.GetAxis("RightAnalogHorizontal1");
        float joyY = Input.GetAxis("RightAnalogVertical1");

        if (joyX != 0 || joyY != 0)
        {
            //Debug.Log("-----------------------------------------");
            float angle = Mathf.Atan2(joyX, joyY) * Mathf.Rad2Deg;
            //Debug.Log(angle);
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
            //Debug.Log(angle);
            angle = Mathf.Lerp(transform.localRotation.eulerAngles.z, angle, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

}
