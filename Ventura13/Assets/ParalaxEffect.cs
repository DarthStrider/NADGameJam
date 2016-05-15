using UnityEngine;
using System.Collections;

public class ParalaxEffect : MonoBehaviour {

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject piece5;
    public GameObject piece6;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        piece1.transform.Translate(0, -3f * Time.deltaTime, 0);
        piece2.transform.Translate(0, -3.4f * Time.deltaTime, 0);
        piece3.transform.Translate(0, -3.8f * Time.deltaTime, 0);
        piece4.transform.Translate(0, -4.2f * Time.deltaTime, 0);
        piece5.transform.Translate(0, -4.6f * Time.deltaTime, 0);
        piece6.transform.Translate(0, -5.0f * Time.deltaTime, 0);

    }
}
