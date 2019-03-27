using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "New Skill/Attack Skill")]
public class AttackSkill : ScriptableObject
{
    public new string descriptionSkill;
    public new string nameSkill;

    public int maxLvl;
    public int realLvl;
    public int Coldown;

    public int Attack;

    public int nextLvlUP;
    public int manaConst;

    public Sprite imageSkill;
}