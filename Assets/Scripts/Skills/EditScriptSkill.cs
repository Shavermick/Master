using UnityEngine;
using UnityEngine.UI;

public class EditScriptSkill : MonoBehaviour {

    public PassiveSkill skill;

    public Text _descriptionSkill;
    public Text _LvlSkill;
    public Image ImageSkill;

    void Start () {
        
        _LvlSkill.text = skill.realLvl.ToString() + " / " + skill.maxLvl.ToString();
        ImageSkill.sprite = skill.imageSkill;
	}
    
    // Метод показывающий описания умения
    //
    public void DescriptionText()
    {
        _descriptionSkill.text = skill.descriptionSkill;
    }

}