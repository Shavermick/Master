using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour {

    public void StartGame()
    {
        Application.LoadLevel("");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}