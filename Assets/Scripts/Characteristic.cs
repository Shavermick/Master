using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Characteristics
{
	public static bool OpenCharacterist(GameObject PanelCharacterisitc, bool Open)
	{
		Open = !Open;
		PanelCharacterisitc.SetActive(Open);
		return Open;
	}

	
}