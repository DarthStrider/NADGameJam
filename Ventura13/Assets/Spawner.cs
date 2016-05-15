using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawner : MonoBehaviour {
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4;
    public GameObject[] asteroids;
    public Camera main;
    public GameObject Ship;
    public Vector2 asteroidAmount;
    public Vector2 heightDifference;
    int heightChance = 1;
    public GameObject environment;


    public GameObject Skybox;
    public float timerTotal = 1.8f;
    public float timer;
    float coolDown = 2f;
    public int StartAsteroidSpawnLocation;
    public float asteroidSpawnTimer;

    public bool unlockAsteroids = false;
	// Use this for initialization
	void Start () {
        asteroids = new GameObject[4];
        asteroids[0] = asteroid1;
        asteroids[1] = asteroid2;
        asteroids[2] = asteroid3;
        asteroids[3] = asteroid4;
        asteroidSpawnTimer = 10;
        //asteroids = asteroid1 }
        timer = timerTotal;
    }
	
	// Update is called once per frame
	void Update () {
        if (unlockAsteroids == true)
        {
            environment.gameObject.SetActive(true);
            if (timer <= 0)
            {
                asteriodGenerator();
                timerTotal -= Time.deltaTime;
                timer = timerTotal;
            }
            else
            {
                timer -= Time.deltaTime;
            }
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
            int randAsteroid = Random.Range(0, 4);
            GameObject newAsteroid = Instantiate(asteroids[(int)randAsteroid], local, Quaternion.identity) as GameObject ;

            float randAsteroidSize = Random.Range(1f, 6f);
            newAsteroid.GetComponent<ObstacleHealth>().Health = 6 * randAsteroidSize;
            newAsteroid.transform.localScale = new Vector3(randAsteroidSize, randAsteroidSize,1);
            
            
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
