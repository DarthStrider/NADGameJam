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
	
	}
	
	// Update is called once per frame
	void Update () {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        float alpha = Mathf.Lerp(brightness.x, brightness.y, lerp);
        render.color = new Color(1f, 1f, 1f, alpha);
    }
}
