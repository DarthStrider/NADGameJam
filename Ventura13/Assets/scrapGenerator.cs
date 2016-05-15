using UnityEngine;
using System.Collections;

public class scrapGenerator : MonoBehaviour {
    public GameObject[] scraps;
    public Vector2 timeDifference;
    float time;
    float timeWait;
    public Camera main;
    

	// Use this for initialization
	void Start () {
        Random.seed = System.DateTime.Now.Millisecond; // resetting the random seed
        time = 0;
        timeWait = Random.Range(timeDifference.x, timeDifference.y);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time>= timeWait)
        {
            float height = Random.Range(Screen.height / 2, Screen.height);
            int rightOrLeft = Random.Range(0, 2);
            Vector2 location;
            if(rightOrLeft == 0)
            {
                 location = main.ScreenToWorldPoint(new Vector2(0 - 2, height));

            }
            else
            {
                 location = main.ScreenToWorldPoint(new Vector2(Screen.width + 2, height));
            }

            int scrapSelector = Random.Range(0, scraps.Length);
            GameObject scrap = Instantiate(scraps[scrapSelector], location, Quaternion.Euler(0, 0, Random.Range(0, 360)))as GameObject;
            if (rightOrLeft == 0)
            {
                scrap.GetComponent<scrap>().setDirection(Quaternion.Euler(0, 0, Random.Range(-25, -75)) * Vector2.right);
            }
            else
            {
                scrap.GetComponent<scrap>().setDirection(Quaternion.Euler(0, 0, Random.Range(25, 75)) * -Vector2.right);

            }
            time = 0;
            timeWait = Random.Range(timeDifference.x, timeDifference.y);
        }
	}
}
