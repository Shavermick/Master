using UnityEngine;
using UnityEngine.UI;

public class ControllerKey : MonoBehaviour {

    [Header("Система")]
    public GameObject _SystemStatys;
    [SerializeField] private static bool OpenSystemStatys;

    [Header("Инвентарь")]
    public GameObject _Inventory;
    [SerializeField] private static bool OpenInventor;

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

        OpenSkill = false;
        _Skill.SetActive(OpenSkill);

        OpenMap = false;
        _Map.SetActive(OpenMap);
	}
	
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
          OpenInventor = Inventory.OpenInventory(_Inventory, OpenInventor);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Characteristic.OpenCharacterist();
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