using UnityEngine;
using System.Collections;

public class tractorBehaviour : MonoBehaviour {

    public GameObject beam;
    GameObject newBeam;
    bool unlock = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            newBeam = Instantiate(beam, transform.position, Quaternion.identity) as GameObject;
            unlock = true;

        }
        if (unlock == true)
        {

            if (newBeam.GetComponent<StartBeam>().pullIn == true)
            {

                Vector3 beamPos = newBeam.GetComponent<StartBeam>().pulling().transform.position;
                newBeam.GetComponent<StartBeam>().pulling().transform.position = Vector2.MoveTowards(new Vector2(beamPos.x, beamPos.y), transform.position, 2 * Time.deltaTime);
            }
        }

    }
}
