using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour {
    float joyX;
    float joyY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GunMovement(Input direction) {
        joyX = Input.GetAxis("Horizontal");
        joyY = Input.GetAxis("Vertical");
    }

}
