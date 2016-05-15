using UnityEngine;
using System.Collections;

public class AsteroidInstantiation : MonoBehaviour {

    public GameObject Spawner;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Ship")
        {
            
            Spawner.GetComponent<Spawner>().unlockAsteroids = true;
        }
    }
}
