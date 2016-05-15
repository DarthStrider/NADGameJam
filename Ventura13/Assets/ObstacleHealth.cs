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
                    Debug.Log(gameObject.tag);
                    this.gameObject.GetComponent<AstroidDestroy>().destAsteroid();
                    Destroy(this.gameObject);
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
            Destroy(col.gameObject);
        }
    }

    
}
