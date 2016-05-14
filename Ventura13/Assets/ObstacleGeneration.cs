using UnityEngine;
using System.Collections;

public class ObstacleGeneration : MonoBehaviour {

	public GameObject[] astroids;


	void Start () {
		Random.seed = System.DateTime.Now.Millisecond;
		InvokeRepeating ("SpawnAstroids", 0, 3.0f);
	}


	private void SpawnAstroids(){

		for (int i = 0; i < 3; i++) {
			int heightRandomizer = Random.Range (4, 10);
			int randomChoice = Random.Range (0, 4);
			float width = Random.Range (0, Screen.width);
			Vector2 s = new Vector2 (width, Screen.height + heightRandomizer);
			Vector2 local = Camera.main.ScreenToWorldPoint (s);
			Instantiate (astroids [randomChoice], local, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
