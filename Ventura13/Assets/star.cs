using UnityEngine;
using System.Collections;

public class star : MonoBehaviour {
    public Vector2 brightness;
    public Vector2 speedOffest;
    public Vector2 scaleOffset;
    public SpriteRenderer render;
    public float duration;
	// Use this for initialization
	void Start () {
        Random.seed = System.DateTime.Now.Millisecond; // resetting the random seed
        float speed = Random.Range(speedOffest.x, speedOffest.y);
        Debug.Log(speed);
        if (speed > 1)
        {
            float diff = (speed - 1)/(speedOffest.y-1);
            float size = (scaleOffset.y - 1) * diff;
            Debug.Log(size);
            size = 1 + size;
            this.transform.localScale = new Vector3 (this.transform.localScale.x * size, this.transform.localScale.y * size, 0);
        }
        else
        {
            float diff = (speed-1) / (1-speedOffest.x);
            float size = (1-scaleOffset.x) * diff;
            Debug.Log(size);
            size = 1 + size;
            this.transform.localScale = new Vector3(this.transform.localScale.x * size, this.transform.localScale.y * size, 0);
        }
    }

    // Update is called once per frame
    void Update () {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        float alpha = Mathf.Lerp(brightness.x, brightness.y, lerp);
        render.color = new Color(1f, 1f, 1f, alpha);
    }
}
