using UnityEngine;
using UnityEngine.UI;
public class SystemControl : MonoBehaviour {

	public GameObject PanelSystemMenu;
	public Button Xmark;

	// Метод для закрытия меню
	//
	public void ReturnGame()
	{
		PanelSystemMenu.SetActive(false);
	}

	// Метод для сохранения игры
	//
	public void SaveGame()
	{

	}
	
	// Метод для загрузки игры
	//
	public void LoadGame()
	{

	}

	// Метод для вызова панели управления
	//
	public void ManagementGame(GameObject PanelManagement)
	{
		PanelSystemMenu.SetActive(false);
		PanelManagement.SetActive(true);
	}

	// Метод для возврата в главное меню
	//
	public void ExitMainMenu(GameObject PanelConfirmation)
	{
		PanelSystemMenu.SetActive(false);
		PanelConfirmation.SetActive(true);
	}

	// Метод для выхода из игры
	//
	public void ExitGame(GameObject PanelConfirmation)
	{
		PanelSystemMenu.SetActive(false);
		PanelConfirmation.SetActive(true);
	}

	// Метод для подтверждения выхода в главное меню
	//
	public void YesExitMenu()
	{
		Application.LoadLevel("Menu");
	}

	// Метод для подтверждения выхода в игру
	//
	public void YesExitGame()
	{
		Application.Quit();
	}

	// Метод для отмены выхода
	//
	public void NoExitAll(GameObject ButtonNo)
	{
		ButtonNo.SetActive(false);
	}

	// Метод для закрытия крестиков
	//
	public static void CloseXMark(bool IsopenPanel, GameObject PanelOpen)
	{
		IsopenPanel = !IsopenPanel;
		PanelOpen.SetActive(IsopenPanel);
	}
}