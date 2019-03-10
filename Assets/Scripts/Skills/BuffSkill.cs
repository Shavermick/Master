using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "New Skill/Buff Skill")]
public class BuffSkill : ScriptableObject
{
    public new string NameSkill;
    public new string descriptionSkill;

    public int Coldown;
    public int maxLvl;
    public int realLvl;

    public float durationSkill;

    public Sprite imageSkill;
}