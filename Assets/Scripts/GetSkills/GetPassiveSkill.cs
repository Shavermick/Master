using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPassiveSkill : MonoBehaviour
{

    public PassiveSkill passiveSkill;

    public Text lvlSkillText;
    public Text descriptionBuffSkill;
    public Button imageSkill;

    void Start()
    {

        imageSkill.image.sprite = passiveSkill.imageSkill;
        lvlSkillText.text = passiveSkill.realLvl + " / " + passiveSkill.maxLvl;

    }

    public void ShowSkill()
    {
        descriptionBuffSkill.text = passiveSkill.NameSkill + ". " + passiveSkill.descriptionSkill + " " + passiveSkill.Effect + passiveSkill.procent + ". Можно улучшить на след. уровне: " + passiveSkill.nextLvlUP + "." ;
    }

    private void LateUpdate()
    {
        lvlSkillText.text = passiveSkill.realLvl + " / " + passiveSkill.maxLvl;
    }
}