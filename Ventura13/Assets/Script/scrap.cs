using UnityEngine;
using System.Collections;

public class scrap : MonoBehaviour {
    Vector2 direction;
    public bool tractorBeamed;
    public bool first;
    Rigidbody2D rb;
    public float moveSpeed;
    public float healingPower;
    public float damagePower;
    Vector3 originalScale;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        first = false;
        tractorBeamed = false;
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -100)
        {
            Debug.Log("here");
            Destroy(this.gameObject);
        }
        if (tractorBeamed == false)
        {
            transform.localScale = originalScale;
            rb.velocity = (direction * moveSpeed);
        }
        if (tractorBeamed == true)
        {
           // transform.localScale = new Vector3(0.05f * transform.localScale.x, 0.05f * transform.localScale.y, 0.05f * transform.localScale.z);
            if (first == false)
            {
                rb.velocity = Vector2.zero;
                first = true;
            }
        }
    }

    public void setDirection(Vector2 v)
    {
        direction = v;
    }

   public void healShip()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().healDamage(healingPower);
    }

     void damageShip()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().TakeDamage(damagePower);
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.transform.tag == "Ship")
        {
            damageShip();
            Destroy(this.gameObject);
        }
    }
}
