using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour
{
    public float health;
    private float maxHealth;


    // Use this for initialization
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=50 && health > 40)
        {

        }
        if(health<=40 && health > 30)
        {

        }
        if(health <=30 && health > 20)
        {

        }
    }

    public void TakeDamage(float x)
    {
        if (health - x <= 0)
        {

        }
        else
        {
            health -= x;
        }
    }

    public void healDamage(float x)
    {
        if (health + x > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            maxHealth += x;
        }
    }
}
