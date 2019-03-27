using UnityEngine;
using UnityEngine.UI;

public class GetAttackSkill : MonoBehaviour {

    public AttackSkill attackSkill;

    public Text lvlSkillText;
    public Text descriptionAttackSkill;
    public Button imageSkill;
    
	void Start () {

        imageSkill.image.sprite = attackSkill.imageSkill;
        lvlSkillText.text = attackSkill.realLvl + " / " + attackSkill.maxLvl;

	}

    public void ShowSkill()
    {
        descriptionAttackSkill.text = attackSkill.nameSkill + ". " + attackSkill.descriptionSkill + ". Атака: " + attackSkill.Attack + ". " + "Перезарядка умения: " + attackSkill.Coldown + " сек. Можно улучшить на след. уровне: " + attackSkill.nextLvlUP + ". Стоимость маны: " + attackSkill.manaConst + ".";
    }

    private void LateUpdate()
    {
        lvlSkillText.text = attackSkill.realLvl + " / " + attackSkill.maxLvl;
    }
}