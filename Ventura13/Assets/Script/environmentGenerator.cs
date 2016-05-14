using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class environmentGenerator : MonoBehaviour {
    Environment env;
    public GameObject star;
    public GameObject cloud;
    public Camera main;
    float time;
    public float cloudDelay;
    public float starDelay;
    public Vector2 cloudAmount;
    public Vector2 starAmount;
    
     
	// Use this for initialization
	void Start () {
        env = Environment.Earth;
        Random.seed = System.DateTime.Now.Millisecond; // resetting the random seed
    }

    // Update is called once per frame
    void Update () {
        if (env == Environment.Earth)
        {
            time += Time.deltaTime;
            if (time >= cloudDelay)
            {
                cloudGenerator();
                time = 0;
            }
        }
        if (env == Environment.Space)
        {
            starGenerator();
        }
        if (env == Environment.Mars)
        {
            marsCloudGenerator();
        }
    }

    private void cloudGenerator()
    {
        List<Vector2> locations = new List<Vector2>();
            int amount = Random.Range((int)cloudAmount.x, (int)cloudAmount.y + 1);
            for (int i = 0; i <= amount; i++)
            {
                float width = Random.Range(0, Screen.width);
                Vector2 spot = new Vector2(width, Screen.height);
                Vector2 local = main.ScreenToWorldPoint(spot);
            local = cloudPlacement(locations, local);
            locations.Add(local);
            Instantiate(cloud, local, Quaternion.identity);

            }
    }

   private Vector2 cloudPlacement(List<Vector2> spots, Vector2 w)
    {
        bool l = false;
        foreach (Vector2 spot in spots)
        {
            if (w.x>spot.x-3 && w.x < spot.x + 3)
            {
                float width = Random.Range(0, Screen.width);
                Vector2 s = new Vector2(width, Screen.height);
                Vector2 local = main.ScreenToWorldPoint(s);
                l = true;
                cloudPlacement(spots, local);
            }
        }
        if (l == false)
        {
            return w;
        }
        else
        {
            return (new Vector2 (-999,-999));
        }
    } 
    
    private void starGenerator()
    {

    }

    private void marsCloudGenerator()
    {

    }
}
