using UnityEngine;
using System.Collections;

public class StartBeam : MonoBehaviour {

    int counter = 0;
    int sideCounter = 0;
    public bool pullIn = false;
    GameObject objPulled;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        counter++;
        if(counter>2 && sideCounter < 10)
        {
            counter = 0;
            transform.localScale += new Vector3(0.15f, 0.5f, 0);
            sideCounter++;
        }


	}
    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Scrap")
        {
            
            pullIn = true;
            objPulled = collider.gameObject;

        }
    }

    public GameObject pulling()
    {
        return objPulled;
    }

}
