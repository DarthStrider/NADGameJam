using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
    public GameObject player3;
    public float speed;
    public GameObject skybox;
    public GameObject floor;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 middle = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2,0));
        Vector2 player = new Vector2(transform.position.x, transform.position.y);
        Vector2 middleToPlayer =  middle - player;
        middleToPlayer = middleToPlayer.normalized;
        player3.GetComponent<Rigidbody2D>().AddForce(middleToPlayer * speed);
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            skybox.GetComponent<SkyBoxScrolling>().start = true;
            Destroy(floor);
            Destroy(this.gameObject);

        }
    }
}
