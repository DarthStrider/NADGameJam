using UnityEngine;
using System.Collections;

public class star : MonoBehaviour {
    public Vector2 durations;
    public Vector2 brightness;
    public Vector2 speedOffset;
    public Vector2 scaleOffset;
    public SpriteRenderer render;
    private float duration;
    private float speed = 2;
    private float speedDiff;
    float speedRatio;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        Random.seed = System.DateTime.Now.Millisecond * Random.Range(0, 100); // resetting the random seed
        Random.seed = System.DateTime.Now.Millisecond * Random.Range(0, 55); // resetting the random seed
        float speedDiff = Random.Range(speedOffset.x, speedOffset.y);
        duration = Random.Range(durations.x, durations.y);
        if (speedDiff > 1)
        {
            float diff = (speedDiff - 1)/(speedOffset.y-1);
            float size = (scaleOffset.y - 1) * diff;
            speedRatio = 1 + size;
            this.transform.localScale = new Vector3 (this.transform.localScale.x * size, this.transform.localScale.y * size, 0);
        }
        else
        {
            float diff = (speedDiff - 1) / (1-speedOffset.x);
            float size = (1-scaleOffset.x) * diff;
            //Debug.Log(size);
            speedRatio = 1 - size;
            this.transform.localScale = new Vector3(this.transform.localScale.x * size, this.transform.localScale.y * size, 0);
        }
    }

    // Update is called once per frame
    void Update () {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        float alpha = Mathf.Lerp(brightness.x, brightness.y, lerp);
        render.color = new Color(1f, 1f, 1f, alpha);
        Debug.Log(speed + "   " + speedRatio);
        rb.AddForce(-Vector2.up * (speed * speedRatio));
        if (transform.position.y <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
