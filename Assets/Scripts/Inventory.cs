using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
	[Header("Panel Inventory")]
	// Переменные для инвенторя
	//
	public GameObject PanelInventory;
	[SerializeField] private bool isOpenInventory;


	// Метод для открытия инвенторя
	//
	public void OpenInventory()
	{
		isOpenInventory = !isOpenInventory;
		PanelInventory.SetActive(isOpenInventory);
	}
	
	void Start()
	{
		isOpenInventory = false;
		PanelInventory.SetActive(isOpenInventory);
	}

	void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			OpenInventory();
		}
	}

}