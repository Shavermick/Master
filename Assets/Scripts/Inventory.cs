using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public static bool OpenInventory(GameObject PanelInventory, bool Open)
	{
		Open = !Open;
		PanelInventory.SetActive(Open);
		return Open;
	}
    
    
}