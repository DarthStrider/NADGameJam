using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour {

    float timer;
    float move;
	// Use this for initialization
	void Start () {
        //Random.seed = System.DateTime.Now.Millisecond;
        move = Random.Range(.1f, 2);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move *Time.deltaTime, 0, 0);
        
        if (transform.position.x > 33)
        {
            transform.position = new Vector3(-33, transform.position.y, transform.position.z);
        }
    
    }
}
