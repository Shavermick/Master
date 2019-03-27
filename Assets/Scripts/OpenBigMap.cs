using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBigMap : MonoBehaviour {

    public GameObject Map;
    public bool OpenMap = false;

	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenMap = !OpenMap;
            Map.SetActive(OpenMap);
        }

	}
}
