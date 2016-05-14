using UnityEngine;
using System.Collections;

public class SwapSprites : MonoBehaviour {

	public GameObject sprite1;
	public GameObject sprite2;

	public void SwapFace(){
		sprite1.GetComponent<SpriteRenderer> ().enabled = false;
		sprite2.GetComponent<SpriteRenderer> ().enabled = true;
	}

	public void SwapSide(){
		sprite1.GetComponent<SpriteRenderer> ().enabled = true;
		sprite2.GetComponent<SpriteRenderer> ().enabled = false;
	}
}
