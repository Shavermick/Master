using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {

    [Header("For visible panel skill")]
    public GameObject _PanelSkill;
    [SerializeField] private bool isOpenPanel;


    [Header("Очки для изучение скилов")]
    public Text _LvlPoints;
    [SerializeField] private byte LvlPointForSkillUp = 0;

    [Header("Info for Skill")]

    // Переменные отвечающие за первое умение
    //
    public Text DescriptionFirstSkill;
    public Text LvlAndMaxLvlFirstSkill;
    [SerializeField] private byte FirstLvlSkill = 0;
    [SerializeField] private byte MaxLvlFirstSkill;
    [SerializeField] private int FirstSkillDamage;


    [Space(20)]

    // Переменные отвечающие за второе умение
    //
    public Text DescriptionSecondSkill;
    public Text RealAndMaxLvlSecondSkill;
    [SerializeField] private byte SecondLvlSkill = 0;
    [SerializeField] private byte MaxLvlSecondSkill = 10;
    [SerializeField] private float TimeContinuationsSecondSkill;

    [Space(20)]

    // Переменные отвечающие за третье умение
    //
    [SerializeField] private byte ThirdLvlSkill;

    // Свойство для получения и проверки Skill Point
    //
    public byte lvlPointForSkillUp
    {
        get { return LvlPointForSkillUp; }
        set
        {
            if (LvlPointForSkillUp < 0)
            {
                LvlPointForSkillUp = 0;
            }
            else
            {
                LvlPointForSkillUp = value;
            }
        }
    }

    // Метод для открытия панели скилов
    //
    public void OpenPanelSkill()
    {
        isOpenPanel = !isOpenPanel;
        _PanelSkill.SetActive(isOpenPanel);
    }

    // Метод для повышение уровня первого умения
    //
    public void UpFirstSkill()
    {
        if (LvlPointForSkillUp != 0)
        {
            lvlPointForSkillUp--;
            DamageSkillFirst();
        }
    }

    // Метод для понижение уровня перого умения
    //
    public void DownFirstSkill()
    {
        if (FirstLvlSkill != 0)
        {
            lvlPointForSkillUp++;
            DamageSkillFirst();
        }
    }
    // Метод для повышение уровня второго умения
    //
    public void UpSecondSkill()
    {
        if (LvlPointForSkillUp != 0)
        {
            SecondLvlSkill++;
            RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
            TimeSkillSecond();
            lvlPointForSkillUp--;
        }
    }

    // Метод для понижения уровня второго умения
    //
    public void DownSecondSkill()
    {
        if (SecondLvlSkill != 0)
        { 
            SecondLvlSkill--;
            RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
            TimeSkillSecond();
            lvlPointForSkillUp++;
        }
    }
   
    // Изменение урона умения в зависимости от уровня скила
    //
    public void DamageSkillFirst()
    {
        switch(FirstLvlSkill)
        {
            case 1:

                break;
            case 2:

                break;
        } 
    }

    // Метод для изменение времени продолжительности умения 
    //
    public void TimeSkillSecond()
    {
        switch (SecondLvlSkill)
        {
            case 1:
                TimeContinuationsSecondSkill = 10f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 2:
                TimeContinuationsSecondSkill = 12f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 3:
                TimeContinuationsSecondSkill = 14f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 4:
                TimeContinuationsSecondSkill = 16f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 5:
                TimeContinuationsSecondSkill = 18f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 6:
                TimeContinuationsSecondSkill = 20f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 7:
                TimeContinuationsSecondSkill = 22f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 8:
                TimeContinuationsSecondSkill = 24f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 9:
                TimeContinuationsSecondSkill = 26f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
            case 10:
                TimeContinuationsSecondSkill = 28f;
                DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
                " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
                RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
                break;
        }
    }

    void Start()
    {
        // Инициализация второго уменя при старте игры
        //
        DescriptionSecondSkill.text = "Баф. Прибавление +20 к скорости передвижения." +
        " Длительность эффекта " + TimeContinuationsSecondSkill.ToString() + " сек";
        RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();

        // Изначально панель закрыта 
        //
        isOpenPanel = false;
        _PanelSkill.SetActive(isOpenPanel);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isOpenPanel = !isOpenPanel;
            _PanelSkill.SetActive(isOpenPanel);
        }

        _LvlPoints.text = lvlPointForSkillUp.ToString();
    }
}