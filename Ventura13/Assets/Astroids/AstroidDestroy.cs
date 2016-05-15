using UnityEngine;
using System.Collections;

public class AstroidDestroy : MonoBehaviour {

    public GameObject debris1;
    public GameObject debris2;
    public GameObject debris3;
    public GameObject debris4;
    public GameObject debris5;
    public GameObject[] debris;
    public AudioSource asteroidDestroySound;




    void Start () {
        asteroidDestroySound.Play();
        debris = new GameObject[5];
        debris[0] = debris1;
        debris[1] = debris2;
        debris[2] = debris3;
        debris[3] = debris4;
        debris[4] = debris5;

    }
	
	// Update is called once per frame
	void Update () {



    }
    public void destAsteroid()
    {

        

        for (int i = 0; i < 5; i++)
        {
            Instantiate(debris[i], transform.position, Quaternion.identity);
            
        }
        

    }






}
