using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class environmentGenerator : MonoBehaviour {
    Environment env;
    public GameObject star;
    public Camera main;
    float time;
    public float starDelay;
    public Vector2 starAmount;
    public Vector2 heightDifference;
    
     
	// Use this for initialization
	void Start () {
        env = Environment.Space;
        Random.seed = System.DateTime.Now.Millisecond; // resetting the random seed
    }

    // Update is called once per frame
    void Update () {
    
        if (env == Environment.Space)
        {
            time += Time.deltaTime;
            if (time >= starDelay)
            {
                starGenerator();
                time = 0;
            }
        }
        if (env == Environment.Mars)
        {
            marsCloudGenerator();
        }
    }


    
    private void starGenerator()
    {
        List<Vector2> locations = new List<Vector2>();
        int amount = Random.Range((int)starAmount.x, (int)starAmount.y);
        for (int i = 0; i <= amount; i++)
        {
            float heightOffset = Random.Range(heightDifference.x, heightDifference.y);
            float width = Random.Range(0, Screen.width);
            Vector2 spot = new Vector2(width, Screen.height+heightOffset);
            Vector2 local = main.ScreenToWorldPoint(spot);
           // local = starPlacement(locations, local);
            locations.Add(local);
            Instantiate(star, local, Quaternion.identity);

        }
    }

    private Vector2 starPlacement(List<Vector2> spots, Vector2 w)
    {
        bool l = false;
        foreach (Vector2 spot in spots)
        {
            if (w.x > spot.x - 1 && w.x < spot.x + 1)
            {
                float width = Random.Range(0, Screen.width);
                Vector2 s = new Vector2(width, Screen.height + 10);
                Vector2 local = main.ScreenToWorldPoint(s);
                l = true;
                starPlacement(spots, local);
            }
        }
        if (l == false)
        {
            return w;
        }
        else
        {
            return (new Vector2(-999, -999));
        }
    }

    private void marsCloudGenerator()
    {

    }
}
