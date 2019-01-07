using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

}
public class Inventorys
{
	public static bool OpenInventory(GameObject PanelInventory, bool Open)
	{
		Open = !Open;
		PanelInventory.SetActive(Open);
		return Open;
	}
}