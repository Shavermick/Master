using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Characteristic characteristic;

    public Cursore cursoreVisible;

    public List<Item> inventory = new List<Item>();

    public Image[] imagesItem = new Image[30];

    public Text[] textsKol = new Text[30];

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

     public void Add(Item item)
     {
        bool isHave = HaveItem(item);

        if (inventory.Count < spaceInventory && !isHave)
        {
            inventory.Add(item);
            imagesItem[serchIndex].sprite = item.icon;
            imagesItem[serchIndex].gameObject.SetActive(true);
            kol[serchIndex] = 1;
            textsKol[serchIndex].text = kol[serchIndex].ToString();
            textsKol[serchIndex].gameObject.SetActive(true);
        }
        else
        {
            kol[serchIndex] += 1;
            textsKol[serchIndex].text = kol[serchIndex].ToString();
        }
     }

    public bool HaveItem(Item item)
    {
        foreach (var itemsInvent in inventory)
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

    public void RemoveItems(GameObject Panel)
    {
        var nameParent = Panel.transform.parent;
        int numberCell = int.Parse(nameParent.name.Substring(4, 1));

        inventory.RemoveAt(numberCell);
        kol[numberCell] = 0;
        textsKol[numberCell].gameObject.SetActive(false);
        imagesItem[numberCell].sprite = null;
        imagesItem[numberCell].gameObject.SetActive(false);
    }

    public void RemoveItems(int cell)
    {
        inventory.RemoveAt(cell);
        kol[cell] = 0;
        textsKol[cell].gameObject.SetActive(false);
        imagesItem[cell].sprite = null;
        imagesItem[cell].gameObject.SetActive(false);
    }

    public void UseItem(GameObject Panel)
    {
        var nameParent = Panel.transform.parent;
        int numberCell = int.Parse(nameParent.name.Substring(4, 1));

        if (kol[numberCell] > 1)
        {
            
            itemsPuse(inventory[numberCell]);
            kol[numberCell] -= 1;
            textsKol[numberCell].text = kol[numberCell].ToString();
        }
        else if (kol[numberCell] == 1)
        {
            itemsPuse(inventory[numberCell]);
            RemoveItems(numberCell);
        }
    }

    public void itemsPuse(Item item)
    {
        switch(item.NameItem)
        {
            case "Банка с зельем здоровья":
                {
                    characteristic.RealHp += item.GiveItem;
                    break;
                }

            case "Банка с зельем маны":
                {
                    characteristic.RealMp += item.GiveItem;
                    break;
                }
            case "Банка с опытом":
                {
                    characteristic.RealExp += item.GiveItem;
                    break;
                }
        }
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
}