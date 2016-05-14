using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject ship;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0, ship.transform.position.y + 9, -1);
	}
}
