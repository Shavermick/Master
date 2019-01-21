using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerKey : MonoBehaviour {

    [Header("Система")]
    public GameObject _SystemStatys;
    [SerializeField] private static bool OpenSystemStatys;

    [Header("Инвентарь")]
    public GameObject _Inventory;
    [SerializeField] private static bool OpenInventor;

    [Header("Характеристики")]
    public GameObject _Characteristic;
    [SerializeField] private static bool OpenCharacteristic;

    [Header("Скилы")]
    public GameObject _Skill;
    [SerializeField] private static bool OpenSkill;

    [Header("Карта")]
    public GameObject _Map;
    [SerializeField] private static bool OpenMap;
    void Start ()
    {
		OpenSystemStatys = false; 
        _SystemStatys.SetActive(OpenSystemStatys);

        OpenInventor = false;
        _Inventory.SetActive(OpenInventor);

        OpenCharacteristic = false;
        _Characteristic.SetActive(OpenCharacteristic);

        OpenSkill = false;
        _Skill.SetActive(OpenSkill);

        OpenMap = false;
        _Map.SetActive(OpenMap);
	}
	
	
	void Update () 
    {
        
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenSystemStatys =SysteamControl.OpenSystem(_SystemStatys,OpenSystemStatys);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
          OpenInventor = Inventorys.OpenInventory(_Inventory, OpenInventor);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenCharacteristic = Characteristic.OpenCharacterist(_Characteristic,OpenCharacteristic);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            OpenSkill = !OpenSkill;
            _Skill.SetActive(OpenSkill);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
             OpenMap = !OpenMap;
            _Map.SetActive(OpenMap);
        }
	}
}