using UnityEngine;

[CreateAssetMenu(fileName ="Skill",menuName ="New Skill/Passive Skill")]
public class PassiveSkill : ScriptableObject
{
    public new string NameSkill;
    public new string descriptionSkill;
    public new string procent;
    public int maxLvl;
    public int realLvl;
   
    public int Effect;

    public int nextLvlUP;

    public Sprite imageSkill;
}