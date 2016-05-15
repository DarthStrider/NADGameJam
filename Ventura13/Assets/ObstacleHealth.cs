﻿using UnityEngine;
using System.Collections;

public class ObstacleHealth : MonoBehaviour {
    public float Health = 50;
    public enum ObstacleType { AST, SAT, BLI};
    public ObstacleType obsType;
    public GameObject PuffHit;
    public GameObject BlimpExp;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Health <= 0)
        {
            switch (obsType) {
                case ObstacleType.AST:
                    this.gameObject.GetComponent<AstroidDestroy>().destAsteroid();
                    Destroy(this.gameObject);
                    break;
                case ObstacleType.SAT:
                    break;

                case ObstacleType.BLI:
                    GameObject bl = Instantiate(BlimpExp, transform.position, Quaternion.identity) as GameObject;

                    Destroy(this.gameObject, 1f);
                    break;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Blimp Interactions");
        if (col.gameObject.tag == "Bullet")
        {
            switch (obsType)
            {
                case ObstacleType.AST:
                    Health -= col.gameObject.GetComponent<BulletForce>().BulletDamage;
                    Destroy(col.gameObject);
                    
                    break;
                case ObstacleType.SAT:

                    break;
                case ObstacleType.BLI:
                    Health -= col.gameObject.GetComponent<BulletForce>().BulletDamage;
                    GameObject ph = Instantiate(PuffHit, col.transform.position, Quaternion.identity) as GameObject;
                    Destroy(ph, .83f);
                    Destroy(col.gameObject);
                    break;

            }

        }
        else if(col.gameObject.tag == "Ship")
        {
            Debug.Log("Blimp Interactions");
            switch (obsType)
            {
                case ObstacleType.AST:
                    col.gameObject.GetComponent<ShipHealth>().TakeDamage(Health);
                    break;
                case ObstacleType.SAT:
                    col.gameObject.GetComponent<ShipHealth>().TakeDamage(Health);
                    break;
                case ObstacleType.BLI:
                    col.gameObject.GetComponent<ShipHealth>().TakeDamage(Health);
                    GameObject bl = Instantiate(BlimpExp, transform.position, Quaternion.identity) as GameObject;
                    
                    Destroy(this.gameObject,1f);
                    break;

            }

        }
    }

    
}
