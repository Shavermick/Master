using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControl : MonoBehaviour {

	public void CloseSystem(GameObject SystemPanel)
	{
		SystemPanel.SetActive(false);
	}

	public void LoadMenu(GameObject PanelСonfirmation)
	{
		PanelСonfirmation.SetActive(true);
	}

	public void CloseDilogPanel(GameObject PanelClose)
	{
		PanelClose.SetActive(false);
	}

	public void LoadMenu()
	{
		Application.LoadLevel("Menu");
	}
	 public void ExitGame()
	{
		Application.Quit();
	}
}

public class SysteamControl
{
	public static bool OpenSystem(GameObject SystemPanel, bool Open)
	{
		Open = !Open;
		SystemPanel.SetActive(Open);
		return Open;
	}
}