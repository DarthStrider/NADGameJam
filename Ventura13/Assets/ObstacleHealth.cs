using UnityEngine;
using System.Collections;

public class ObstacleHealth : MonoBehaviour {
    public float Health = 50;
    public enum ObstacleType { AST, SAT};
    public ObstacleType obsType;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Health <= 0)
        {
            switch (obsType) {
                case ObstacleType.AST:
                    gameObject.GetComponent<AstroidDestroy>().destAsteroid();
                    break;
                case ObstacleType.SAT:
                    break;
            
             }
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
