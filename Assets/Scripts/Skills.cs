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
    [SerializeField] private byte FirstLvlSkill;
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
    
    
    // Метод для открытия панели скилов
    //
    public void OpenPanelSkill()
    {
        isOpenPanel = !isOpenPanel;
        _PanelSkill.SetActive(isOpenPanel);
    }

    // Метод для повышение уровня первого умения
    //
    public void UpFirstSlill()
    {
        FirstLvlSkill++;
        RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
        TimeSkillSecond();
        LvlPointForSkillUp --;
    }

    // Метод для понижения уровня первого умения
    //
    public void DownFirstSkill()
    {
        FirstLvlSkill--;
        RealAndMaxLvlSecondSkill.text = SecondLvlSkill.ToString() + " / " + MaxLvlSecondSkill.ToString();
        TimeSkillSecond();
        LvlPointForSkillUp ++;
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
                break;
            case 2:
                TimeContinuationsSecondSkill = 12f;
                break;
            case 3:
                TimeContinuationsSecondSkill = 14f;
                break;
            case 4:
                TimeContinuationsSecondSkill = 16f;
                break;
            case 5:
                TimeContinuationsSecondSkill = 18f;
                break;
            case 6:
                TimeContinuationsSecondSkill = 20f;
                break;
            case 7:
                TimeContinuationsSecondSkill = 22f;
                break;
            case 8:
                TimeContinuationsSecondSkill = 24f;
                break;
            case 9:
                TimeContinuationsSecondSkill = 26f;
                break;
            case 10:
                TimeContinuationsSecondSkill = 28f;
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
    }
}