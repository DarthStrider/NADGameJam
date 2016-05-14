using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class tractorBehaviour : MonoBehaviour {
	public GameObject origin;
    public GameObject beam;
	bool shootRay;
	bool capturing;
	bool atShip;
	bool pressed;
	bool hitObject;
	bool laserShot;
	float  length;
	public float tractorDistance;
	GameObject capturedObject;
	List <GameObject> beams = new List<GameObject>();
    GameObject newBeam;
	public float laserDelay;
	float time;
	float distance;
	// Use this for initialization
	void Start () {
		length = 0;
		time = 0;
		pressed = false;
		laserShot = false;
		 shootRay = false;
		 capturing = false;
		 atShip = false;
		hitObject = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("RT2") <= 0 && pressed == true) {
			length = 0;
			time = 0;
			pressed = false;
			laserShot = false;
			shootRay = false;
			capturing = false;
			atShip = false;
			hitObject = false;
				foreach (GameObject beam in beams) {
					Destroy (beam);
				}
			beams.Clear ();
		}

		if (Input.GetAxis("RT2")>0 && pressed == false)
        {
			pressed = true;
			//Debug.DrawRay(origin.transform,transform
			RaycastHit2D hit = Physics2D.Raycast(origin.transform.position,origin.transform.up,tractorDistance);

			if (hit != null && hit.collider != null) {
				capturedObject = hit.collider.gameObject;
				distance = hit.distance;
				shootRay = true;
				hitObject = true;
			} 
			else {
				distance = tractorDistance;
				shootRay = true;
			}


        }

		if (shootRay == true && laserShot == false) {
			laserShot = true;
			Debug.Log (distance);
			for (int i = 0; i < distance; i++) {
				GameObject b;

				b = Instantiate (beam, origin.transform.position + (i * origin.transform.up), Quaternion.identity) as GameObject;
				//origin = b;
				beams.Add (b);
			}
		}

			if (hitObject == false) {
				time += Time.deltaTime;
				if (time > laserDelay) {
					foreach (GameObject beam in beams) {
						Destroy (beam);
					}
				length = 0;
				time = 0;
				laserShot = false;
				shootRay = false;
				capturing = false;
				atShip = false;
				hitObject = false;
				beams.Clear ();
				}
			}

			if (hitObject == true) {
			capturedObject.transform.position = Vector2.MoveTowards(capturedObject.transform.position ,origin.transform.position, 2 *  Time.deltaTime);
				length += 2 * Time.deltaTime;
				if(length>=1){
					Destroy (beams[beams.Count - 1]);
					beams.RemoveAt (beams.Count - 1);
					length = 0;

				}
					

			}

    }

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Scrap") {
			if (hitObject == true) {
				Destroy (col.gameObject);
				length = 0;
				time = 0;
				laserShot = false;
				shootRay = false;
				capturing = false;
				atShip = false;
				hitObject = false;
				foreach (GameObject beam in beams) {
					Destroy (beam);
				}
				beams.Clear ();
			}

		}

	}

}