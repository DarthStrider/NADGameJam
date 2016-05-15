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

    public void gunMovement(Vector2 input)
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

    public void shoot(int playerIndex)
    {
        if (cooldownTimer <= 0)
        {
            GameObject laser = Instantiate(bullet, bulletSpawn.position, bulletSpawn.localRotation) as GameObject;
            laser.GetComponent<BulletForce>().Initalize(bulletSpawn);
            cooldownTimer = cooldownTime;
            this.GetComponent<x360_Gamepad>().AddRumble(playerIndex-1, 0.2f, new Vector2(5.0f, 5.0f));
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
}
