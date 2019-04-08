using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursore : MonoBehaviour {

    public bool isVisible;
    [SerializeField] private int kolOpenPanel;
	// Use this for initialization
	void Start () {

        isVisible = false;
        Cursor.visible = isVisible;

	}

    public void isVisibleCursore(bool openBool)
    {
        if (openBool)
        {
            isVisible = true;
            Cursor.visible = isVisible;
            kolOpenPanel += 1;
        }
        else
        {
            kolOpenPanel -= 1;
            if (kolOpenPanel == 0)
            {
                isVisible = false;
                Cursor.visible = isVisible;
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
           
            isVisible = !isVisible;
            Cursor.visible = isVisible;
            Cursor.lockState = CursorLockMode.None;
        }

	}
}
