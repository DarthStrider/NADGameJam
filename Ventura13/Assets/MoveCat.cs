﻿using UnityEngine;
using System.Collections;

public class MoveCat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -1 * Time.deltaTime, 0);
    }
}