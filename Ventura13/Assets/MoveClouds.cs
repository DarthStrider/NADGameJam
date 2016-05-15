using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour {

    private float timer;
    private float move;
    private int layer;
    SpriteRenderer render;
	// Use this for initialization
	void Start () {

        render = GetComponent<SpriteRenderer>();
        layer = render.sortingOrder;
        Debug.Log(layer);

        if(layer == -6)
        {
            move = .8f;
        }

        if (layer == -5)
        {
            move = .4f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move *Time.deltaTime, 0, 0);
        transform.Translate(0, -.2f * Time.deltaTime, 0);

        if (transform.position.x > 32)
        {
            transform.position = new Vector3(-32, transform.position.y, transform.position.z);
        }
    
    }
}
