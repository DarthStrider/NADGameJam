using UnityEngine;
using System.Collections;

public class AstroidDestroy : MonoBehaviour {

    public GameObject[] debris;

    private float health = 50;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        health--;

        if (health <= 0)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            Destroy(this.gameObject);
            health = 1000000;
            for(int i =0; i < 8; i++)
            {
                Instantiate(debris[i], transform.position, Quaternion.identity);
            }
        }
	}
}
