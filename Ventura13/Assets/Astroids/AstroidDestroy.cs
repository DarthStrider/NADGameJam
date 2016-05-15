using UnityEngine;
using System.Collections;

public class AstroidDestroy : MonoBehaviour {

    public GameObject[] debris;




    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



    }
    public void destAsteroid()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(debris[i], transform.position, Quaternion.identity);
            
        }
        Destroy(this.gameObject);

    }






}
