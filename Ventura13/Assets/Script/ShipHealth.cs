using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public GameObject[] lights;
    public GameObject[] exterior;
    bool damaged;
    bool first;
    bool second;
    bool third;
    float time;
    public float wait;
    public float onWait;
    float onTime;
    public GameObject text;
    public GameObject dead;
    // Use this for initialization
    void Start()
    {
        onTime = 0;
        time = 0;
        first = false;
        second = false;
        third = false;
        damaged = false;
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health/maxHealth > 0.3f)
        {
            foreach (GameObject light in lights)
            {
                light.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }

            foreach (GameObject ex in exterior)
            {
                ex.gameObject.SetActive(false);
            }
        }
      
        if(health/maxHealth <=0.3f)
        {
            foreach (GameObject light in lights)
            {
                light.gameObject.GetComponent<SpriteRenderer>().color = new Color(253/255f, 91/255f, 91/255f, 1f);
            }
            foreach (GameObject ex in exterior)
            {
                ex.gameObject.SetActive(true);
            }
        }

        if (damaged==true)
        {

            if (first == true)
            {
                time += Time.deltaTime;
                if (time < wait / 2)
                {
                    foreach (GameObject light in lights)
                    {
                        light.gameObject.SetActive(false);
                    }
                }
                if (time >= wait / 2) { 
                    foreach (GameObject light in lights)
                    {
                        light.gameObject.SetActive(true);
                    }
                    onTime += Time.deltaTime;
                    if (onTime >= onWait)
                    {
                        time = 0;
                        onTime = 0;
                        second = true;
                        first = false;
                    }
                }
            }
            if (second == true)
            {
                time += Time.deltaTime;
                if (time < wait / 2)
                {
                    foreach (GameObject light in lights)
                    {
                        light.gameObject.SetActive(false);
                    }
                }
                if (time >= wait / 2)
                {
                    foreach (GameObject light in lights)
                    {
                        light.gameObject.SetActive(true);
                    }
                    onTime += Time.deltaTime;
                    if (onTime >= onWait)
                    {
                        time = 0;
                        onTime = 0;
                        second = true;
                        first = false;
                    }
                }
            }
            if (third == true)
            {
                foreach (GameObject light in lights)
                {
                    light.gameObject.SetActive(false);
                }

                time += Time.deltaTime;
                if (time >= wait)
                {
                    foreach (GameObject light in lights)
                    {
                        light.gameObject.SetActive(true);
                    }
                    time = 0;
                    third = false;
                    damaged = false;
                }
            }

        }
    }

    public void TakeDamage(float x)
    {
        if (health - x <= 0)
        {
           
            dead.SetActive(true);
            Destroy(this.gameObject);
            Time.timeScale = 0;
            Debug.Log("dead");


        }
        else
        {
            if (damaged == false)
            {
                first = true;
                damaged = true;
            }
            health -= x;
            Text txt = text.gameObject.GetComponent<Text>();
            txt.text = ((int)((health / maxHealth) * 100)) + "%";
        }
    }

    public void healDamage(float x)
    {
        if (health + x > maxHealth)
        {
            health = maxHealth;
            Text txt = text.gameObject.GetComponent<Text>();
            txt.text = ((int)((health / maxHealth) * 100)) + "%";
        }
        else
        {
            maxHealth += x;
            Text txt = text.gameObject.GetComponent<Text>();
            txt.text = ((int)((health / maxHealth) * 100)) + "%";
        }
    }
}
