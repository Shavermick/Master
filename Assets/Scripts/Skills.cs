using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {

    public Cursore cursore;

    public Characteristic attackCharacteristic;

    public Image PassiveSkill;

    [Header("For visible panel skill")]
    public GameObject _PanelSkill;
    public Text descriptionSkill;
    [SerializeField] private bool isOpenPanel;

    [Header("Info about SP")]
    public Text glassesSP;
    public int SP;

    [Header("Место для скилов")]
    public AttackSkill attackSkill;
    public BuffSkill buffSkill;
    public PassiveSkill passiveSkill;

    public float NewWalkSpeed;
    public float NewRunSpeed;

    public bool isSPNotNull(int sp)
    {
        if (sp !=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region Прокачка первого умения

    public void UplvlSkillFist ()
    {
        bool isNotNull;
        if (isNotNull = isSPNotNull(SP) && attackSkill.realLvl != attackSkill.maxLvl && attackCharacteristic.Lvl >= attackSkill.nextLvlUP)
        {
            attackSkill.realLvl++;
            SP--;
            attackSkill.nextLvlUP += 2;
            attackSkill.Attack += 200;
            attackSkill.manaConst += 150;
        }
    }

    public void DownLvlSkillFirst()
    {
        if (attackSkill.realLvl != 0)
        {
            SP++;
            attackSkill.realLvl--;
            attackSkill.nextLvlUP -= 2;
            attackSkill.Attack -= 200;
            attackSkill.manaConst -= 150;
        }
    }
    #endregion

    #region Прокачка второго умения

    public void UpLvlSkillSecond()
    {
        bool isNotNull;
        if (isNotNull = isSPNotNull(SP) && buffSkill.realLvl != buffSkill.maxLvl && attackCharacteristic.Lvl >= buffSkill.nextLvlUP)
        {
            buffSkill.realLvl++;
            SP--;
            buffSkill.durationSkill += 3;
            buffSkill.Coldown -= 5;

            buffSkill.nextLvlUP += 2;

            buffSkill.Effect += 3;

            buffSkill.manaConst += 60;

            NewRunSpeed = 10 + buffSkill.Effect;
            NewWalkSpeed = 5 + buffSkill.Effect;
        }
    }

    public void DonwlvlSkillSecond()
    {
        if (buffSkill.realLvl != 0)
        {
            SP++;
            buffSkill.realLvl--;
            buffSkill.durationSkill -= 3;
            buffSkill.Coldown += 5;

            buffSkill.nextLvlUP -= 2;

            buffSkill.Effect -= 3;

            buffSkill.manaConst -= 60;
        }
    }
    #endregion

    #region Прокачка третьего умения

    public void UplvlSkillThird()
    {
        bool isNotNull;
        if (isNotNull = isSPNotNull(SP) && passiveSkill.realLvl != passiveSkill.maxLvl && attackCharacteristic.Lvl >= passiveSkill.nextLvlUP)
        {
            passiveSkill.realLvl++;
            SP--;
            passiveSkill.Effect +=3;

            attackCharacteristic.MinPhysicalAttack += Mathf.Round((attackCharacteristic.MinPhysicalAttack * passiveSkill.Effect) / 100);
            attackCharacteristic.MaxPhysicalAttack += Mathf.Round((attackCharacteristic.MaxPhysicalAttack * passiveSkill.Effect) / 100);

            PassiveSkill.gameObject.SetActive(true);

            passiveSkill.nextLvlUP += 3;
        }
    }

    public void DonwlvlSkillThird()
    {
        if (passiveSkill.realLvl != 0)
        {
            SP++;
            passiveSkill.realLvl--;
            passiveSkill.Effect -= 3;

            attackCharacteristic.MinPhysicalAttack -= attackCharacteristic.MinPhysicalAttack - Mathf.Round((attackCharacteristic.MinPhysicalAttack * 100) / (100 + passiveSkill.Effect));
            attackCharacteristic.MaxPhysicalAttack -= attackCharacteristic.MaxPhysicalAttack - Mathf.Round((attackCharacteristic.MaxPhysicalAttack * 100) / (100 + passiveSkill.Effect));

            passiveSkill.nextLvlUP -= 3;

            if (passiveSkill.realLvl == 0)
            {
                PassiveSkill.gameObject.SetActive(false);
            }
        }
    }

    #endregion
    // Метод для открытия панели скилов
    //
    public void OpenPanelSkill()
    {
        isOpenPanel = !isOpenPanel;
        _PanelSkill.SetActive(isOpenPanel);

        cursore.isVisibleCursore(isOpenPanel);
    }

    void Start()
    {
        // Изначально панель закрыта 
        //
        isOpenPanel = false;
        _PanelSkill.SetActive(isOpenPanel);
        SP = 3;

        PassiveSkill.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        glassesSP.text = SP.ToString();
        if (Input.GetKeyDown(KeyCode.K))
        {
            OpenPanelSkill();
            descriptionSkill.text = "";
        }
    }
}