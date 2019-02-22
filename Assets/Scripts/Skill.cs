using UnityEngine;

[CreateAssetMenu(fileName ="Skill",menuName ="Skill")]
public class Skill : ScriptableObject
{
    public int maxLvl;
    public int realLvl;
    public new string descriptionSkill;
    public int Effect;
    public Sprite imageSkill;
}
