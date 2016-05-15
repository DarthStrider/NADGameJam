using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawner : MonoBehaviour {
    public GameObject asteroid;
    public Camera main;
    public GameObject Ship;
    public Vector2 asteroidAmount;
    public Vector2 heightDifference;
    int heightChance = 1;

    float timer = 0f;
    float coolDown = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (timer > 2)
        {
            asteriodGenerator();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }


    void spawnAsteroids(GameObject ship)
    {



    }


    private void asteriodGenerator()
    {
        List<Vector2> locations = new List<Vector2>();
        int amount = Random.Range((int)asteroidAmount.x, (int)asteroidAmount.y);
        for (int i = 0; i <= amount; i++)
        {
            float heightOffset = Random.Range(heightDifference.x, heightDifference.y);
            float width = Random.Range(0, Screen.width);
            Vector2 spot = new Vector2(width, Screen.height + heightOffset);
            Vector2 local = main.ScreenToWorldPoint(spot);
            // local = starPlacement(locations, local);
            locations.Add(local);
            GameObject newAsteroid = Instantiate(asteroid, local, Quaternion.identity) as GameObject ;


        }
    }

    private Vector2 asteriodPlacement(List<Vector2> spots, Vector2 w)
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
                asteriodPlacement(spots, local);
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
}
