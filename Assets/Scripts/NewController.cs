﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Debug.Log(ver);
	}
}
