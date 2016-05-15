using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    public float leftWorldAngle;
    public float rightWorldAngle;
    public GameObject gunPodSprite;

    public Transform bulletSpawn;
    public GameObject bullet;
    public float cooldownTime = .2f;
    private float cooldownTimer = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void gunMovement(Vector2 input)
    {
        //Debug.Log(Input.GetJoystickNames().Length);
        float joyX = Input.GetAxis("RightAnalogHorizontal1");
        float joyY = Input.GetAxis("RightAnalogVertical1");

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

    public void shoot()
    {
        if (cooldownTimer <= 0)
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            bullet.GetComponent<BulletForce>().parentShooter = bulletSpawn;
            cooldownTimer = cooldownTime;
            this.GetComponent<x360_Gamepad>().AddRumble(0, 0.5f, new Vector2(10.0f, 10.0f));
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
}
