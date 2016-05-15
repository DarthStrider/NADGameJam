using UnityEngine;
using System.Collections;

public class SkyBoxScrolling : MonoBehaviour {
    public bool start;
    float speed;
    public float maxSpeed;

	// Use this for initialization
	void Start () {
        speed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	if (start == true)
        {
            transform.position += -transform.up * speed;
        }
	}
}
