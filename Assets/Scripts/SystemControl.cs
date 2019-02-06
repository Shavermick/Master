using UnityEngine;
using UnityEngine.UI;
public class SystemControl : MonoBehaviour {

	// Для системной панели
	//
	public GameObject PanelSystemMenu;
	[SerializeField] private bool isOpenMenuSystem;

	// Метод для закрытия меню
	//
	public void ReturnGame()
	{
		isOpenMenuSystem = false;
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
		isOpenMenuSystem = false;
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
		isOpenMenuSystem = false;
	}

	// Метод для открытия панели 
	//
	public void OpenSystem()
	{
		isOpenMenuSystem = !isOpenMenuSystem;
		PanelSystemMenu.SetActive(isOpenMenuSystem);
	}
	
	void Start()
	{
		isOpenMenuSystem = false;
		PanelSystemMenu.SetActive(isOpenMenuSystem);
	}

	void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OpenSystem();
		}
	}
}