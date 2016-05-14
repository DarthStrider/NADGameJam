using UnityEngine;
using System.Collections;

public class HeadBob : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	public void increaseSpeed(float speed){
		anim.speed = speed;
	}
}