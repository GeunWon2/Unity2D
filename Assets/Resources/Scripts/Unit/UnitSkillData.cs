using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    Single,
    Multi
}

public enum SkillType
{
    Buff,
    Attack
}

[CreateAssetMenu(fileName = "SkillData", menuName = "SkillData")]
public class UnitSkillData : ScriptableObject
{
    public string skillName;
    public TargetType targetType;
    public SkillType skillType;
    public int skillValue;
    public float coolTime;
    public int price;
    public int GetValue()
    {
        return skillValue * SkillTypeInit();
    }

    private int SkillTypeInit()
    {
        int value = 0;

        switch (skillType)
        {
            case SkillType.Buff:
                value = 1;
                break;
            case SkillType.Attack:
                value = -1;
                break;
        }
        return value;
    }

}
