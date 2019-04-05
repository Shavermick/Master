using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Cursore cursoreVisible;

    public List<Item> inventory = new List<Item>();

    public static int spaceInventory = 30;

    public int[] kol = new int[spaceInventory];

    public int serchIndex;

	[Header("Panel Inventory")]
	// Переменные для инвенторя
	//
	public GameObject PanelInventory;
	[SerializeField] private bool isOpenInventory;

    [Header("Gold")]
    public Text kolGoldCoint;
    public int GoldCoint;
    public Text kolSilverCoint;
    public int SilverCoint;
    public Text kolBronzeCoint;
    public int BronzeCoint;

	// Метод для открытия инвенторя
	//
	public void OpenInventory()
	{
		isOpenInventory = !isOpenInventory;
		PanelInventory.SetActive(isOpenInventory);

        cursoreVisible.isVisibleCursore(isOpenInventory);
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

        kolGoldCoint.text = GoldCoint.ToString();
        kolSilverCoint.text = SilverCoint.ToString();
        kolBronzeCoint.text = BronzeCoint.ToString();

        if (BronzeCoint >= 100)
        {
            BronzeCoint -= 100;
            SilverCoint += 1;
        }

        if (SilverCoint >= 100)
        {
            SilverCoint -= 100;
            GoldCoint += 1;
        }
        
	}

    public void Add(Item item)
    {
        bool isHave = HaveItem(item);

        if (inventory.Count < spaceInventory && !isHave)
        {
            inventory.Add(item);
            kol[serchIndex] = 1;
        }
        else
        {
            kol[serchIndex] += 1;
        }
    }

    public bool HaveItem(Item item)
    {
        foreach(var itemsInvent in inventory)
        {
            if (itemsInvent == item)
            {
                serchIndex = inventory.IndexOf(itemsInvent);
                return true;
            }
        }

        serchIndex = inventory.Count;
        return false;
    }
}