using UnityEngine;
using System.Collections;

public class SmokePuffScript : MonoBehaviour {

    private float timer;

    // Use this for initialization
    void Start ()
    {
        timer = 0.84f;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
}
