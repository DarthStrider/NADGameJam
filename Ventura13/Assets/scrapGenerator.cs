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
            float width = Random.Range(0, Screen.width);
            int rightOrLeft = Random.Range(0, 2);
            Vector2 location;
          
                 location = main.ScreenToWorldPoint(new Vector2(width,Screen.height+1 ));

           

            int scrapSelector = Random.Range(0, scraps.Length);
            GameObject scrap = Instantiate(scraps[scrapSelector], location, Quaternion.Euler(0, 0, Random.Range(0, 360)))as GameObject;
           
                scrap.GetComponent<scrap>().setDirection(-Vector2.up);

            
            time = 0;
            timeWait = Random.Range(timeDifference.x, timeDifference.y);
        }
	}
}
