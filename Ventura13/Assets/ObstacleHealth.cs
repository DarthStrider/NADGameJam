using UnityEngine;
using System.Collections;

public class ObstacleHealth : MonoBehaviour {
    public float Health = 50;
    public enum ObstacleType { AST, SAT, BLI};
    public ObstacleType obsType;
    public GameObject PuffHit;
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
            
             }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Bullet")
        {
            switch (obsType)
            {
                case ObstacleType.AST:
                    Health -= col.gameObject.GetComponent<BulletForce>().BulletDamage;
                    
                    break;
                case ObstacleType.SAT:

                    break;
                case ObstacleType.BLI:
                    GameObject ph = Instantiate(PuffHit, col.transform.position, Quaternion.identity) as GameObject;
                    Destroy(ph, .83f);
                    Destroy(col.gameObject);
                    break;

            }

        }
    }

    
}
