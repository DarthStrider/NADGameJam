using UnityEngine;
using System.Collections;

public class ObstacleHealth : MonoBehaviour {
    public float Health = 50;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Health -= col.gameObject.GetComponent<BulletForce>().BulletDamage;
        }
    }
}
