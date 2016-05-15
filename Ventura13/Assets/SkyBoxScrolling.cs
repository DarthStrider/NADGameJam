using UnityEngine;
using System.Collections;

public class SkyBoxScrolling : MonoBehaviour {
    public bool start;


	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
	if (start == true)
        {
            
            transform.Translate(0, -1 * Time.deltaTime, 0);
        }
	}  
}
