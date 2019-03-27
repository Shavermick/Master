using UnityEngine;
using UnityEngine.UI;

public class Characteristic : MonoBehaviour {

    [Header("For Panel Characteristic")]
    [SerializeField] public GameObject _PanelCharacteristic;
    [SerializeField] private bool isOpenCharacteristic;

    [Header("Skill Point")]
    [SerializeField] private Skills sP;

    [Header("Text Basic Info")]
    public Text _ClassPlayer;
    public Text _Lvl;
    public Text _HP;
    public Text _MP;

    [Header("Text Basic Characteristic")]
    public Text _Strength;
    public Text _Agility;
    public Text _Intelligence;
    public Text _Vitality;

    [Header("Text Characteristic Attack and Def")]

    public Text _MaxAndMinPhAttack;
    public Text _MaxAndMinMgAttack;
    public Text _PhysicalDef;
    public Text _MagicDef;

    [Header("GUI HP MP EXP NamePlayer")]
    public Image _HpBar;
    public Image _MpBar;
    public Image _ExpBar;

    public Text _NamePlayer;
    public Text _LvlInfo;

    [SerializeField] private string NamePlayer;
    [SerializeField] private float NeedExp;
    [SerializeField] private float RealExp;

    [Header("Basic Info")]

    public int Lvl;
    [SerializeField] private string ClassPlayer;
    [SerializeField] private float MaxHP;
    public float RealHp;
    [SerializeField] private float MaxMp;
    public float RealMp;

    [Header("Basic Characteristic")]

    [SerializeField] private int Strength;
    [SerializeField] private int Agiliy;
    [SerializeField] private int Intelligence;
    [SerializeField] private int Vitality;

    [Header("Characteristic Attack and Def")]

    public float MinPhysicalAttack;
    public float MaxPhysicalAttack;
    public float MinMagicAttack;
    public float MaxMagicAttack;
    [SerializeField] private int PhysicalDef;
    [SerializeField] private int MagicDef;

    // Метод для проверки отрицаемость 
    //
    public float _Health 
    {
        set
        {
            if (RealHp < 0)
            {
                RealHp = 0;
            }
        }
        get { return RealHp; }
    }

    public float _Mana
    {
        set
        {
            if (RealMp < 0)
            {
                RealMp = 0;
            }
        }

        get { return RealMp; }
    }



    // Метод для открытия панели характеристик
    //
    public void OpenCharacterist()
	{
        isOpenCharacteristic = !isOpenCharacteristic;
        _PanelCharacteristic.SetActive(isOpenCharacteristic);
    }
	
    // Метод для расчета HP MP EXP
    //
    public float CalculationHpMpExp(float RealNamber,  float MaxNamber)
    {
        return RealNamber / MaxNamber;
    }

    // Метод для повышение лвл
    //
    public void LvlUp()
    {
        RealExp -= NeedExp;
        NeedExp += 500;

        sP.SP += 3;

        // Увеличение Basic характеристик
        //
        Lvl++;
        _LvlInfo.text = Lvl.ToString();
        MaxHP += 500;
        MaxMp += 500;
        RealHp = MaxHP;
        RealMp = MaxMp;

        Strength += 5;
        Agiliy += 5;
        Intelligence += 5;
        Vitality += 5;

        // Увеличение Attck и Def характеристик
        //
        MinPhysicalAttack += PhysiclAttck(MinPhysicalAttack, Strength, Agiliy); //
        MaxPhysicalAttack += PhysiclAttck(MaxPhysicalAttack, Strength, Agiliy); // Обращение к методам для расчета
        MinMagicAttack += MagicAttack(MinMagicAttack, Intelligence); // атаки в зависимости от Basic характеристик
        MaxMagicAttack += MagicAttack(MaxMagicAttack, Intelligence); //
        PhysicalDef += 50;
        MagicDef += 50;
    }

    // Методы для расчета атаки в зависимости от добавленных характеристик
    //
    public int PhysiclAttck(float PhysicAttack, int Str, int Agl)
    {
        return (int)Mathf.Round((PhysicAttack * Str) / Agl);
    }

    public int MagicAttack(float MagicAttack, int Int)
    {
        return (int)Mathf.Round((MagicAttack * Int) / 25f);
    }

    void Start()
    {
        // Изночально панель характеристик закрыта
        //


        // Инициализация начальных характеристик персонажа
        //
        ClassPlayer = "Мечник";
        Lvl = 1;
        MaxHP = 500;
        MaxMp = 500;
        
        Strength = 20;
        Agiliy = 25;
        Intelligence = 15;
        Vitality = 20;

        MinPhysicalAttack = 150;
        MaxPhysicalAttack = 300;
        MinMagicAttack = 100;
        MaxMagicAttack = 150;
        PhysicalDef = 200;
        MagicDef = 150;

        _ClassPlayer.text = ClassPlayer;

        RealHp = MaxHP;
        RealMp = MaxMp;

        NeedExp = 1000;

        _LvlInfo.text = Lvl.ToString();
    }

    void LateUpdate()
    {

        if (RealMp != MaxMp)
        {
            float regenerate = Mathf.Floor((1 * Time.deltaTime)* 100);

            RealMp += regenerate;

            if (RealMp >= MaxMp)
            {
                RealHp = MaxMp;
            }
        }

        // Заполнение характеристик
        //
        _Lvl.text = Lvl.ToString();
        _HP.text = RealHp.ToString();
        _MP.text = RealMp.ToString();

        _Strength.text = Strength.ToString();
        _Agility.text = Agiliy.ToString();
        _Intelligence.text = Intelligence.ToString();
        _Vitality.text = Vitality.ToString();

        _MaxAndMinPhAttack.text = MinPhysicalAttack.ToString() + " ~ " + MaxPhysicalAttack.ToString();
        _MaxAndMinMgAttack.text = MinMagicAttack.ToString() + " ~ " + MaxMagicAttack.ToString();
        _PhysicalDef.text = PhysicalDef.ToString();
        _MagicDef.text = MagicDef.ToString();
        
        // Заполнение GUI баров
        //
        _HpBar.fillAmount = CalculationHpMpExp(RealHp, MaxHP);
        _MpBar.fillAmount = CalculationHpMpExp(RealMp, MaxMp);
        _ExpBar.fillAmount = CalculationHpMpExp(RealExp, NeedExp) ;

        if (RealExp >= NeedExp)
        {
            LvlUp();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenCharacterist();
        }
    }
}