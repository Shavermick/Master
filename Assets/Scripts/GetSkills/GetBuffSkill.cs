using UnityEngine;
using UnityEngine.UI;

public class GetBuffSkill : MonoBehaviour {

    public BuffSkill buffSkill;

    public Text lvlSkillText;
    public Text descriptionBuffSkill;
    public Button imageSkill;

    void Start()
    {

        imageSkill.image.sprite = buffSkill.imageSkill;
        lvlSkillText.text = buffSkill.realLvl + " / " + buffSkill.maxLvl;

    }

    public void ShowSkill()
    {
        descriptionBuffSkill.text =  buffSkill.NameSkill + ". " + buffSkill.descriptionSkill + ". Бонус скорости: " + buffSkill.Effect + ". Продолжительность: " + buffSkill.durationSkill + " сек. " + "Перезарядка: " + buffSkill.Coldown + " сек. Можно улучшить на след. уровне: " + buffSkill.nextLvlUP + ". Стоимость маны: " + buffSkill.manaConst + ".";
    }

    private void LateUpdate()
    {
        lvlSkillText.text = buffSkill.realLvl + " / " + buffSkill.maxLvl;
    }
}