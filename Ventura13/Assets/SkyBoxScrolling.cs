using UnityEngine;
using System.Collections;

public class SkyBoxScrolling : MonoBehaviour {
    public GameObject skybox;

  

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
       
            skybox.transform.Translate(0, -1 * Time.deltaTime, 0);
        
	}  
}
