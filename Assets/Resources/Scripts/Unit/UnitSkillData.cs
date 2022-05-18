using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    SingleTarget,
    MultiTarget
}

public enum ImfactValue
{
    Heal,
    Damage
}

[CreateAssetMenu(fileName = "SkillData", menuName = "Unit/Skill Data", order = 2)]
public class UnitSkillData : ScriptableObject
{
    public string skillName;
    public ImfactValue imfactValue;
    public int value;
    public float coolTime;
    public TargetType targetType;

    public int GetValue()
    {
        return value * ValueImfactResult();
        //return Random.Range(valueRange.x, valueRange.y) * ValueImfactResult();
    }

    private int ValueImfactResult()
    {
        int value = 0;

        switch(imfactValue)
        {
            case ImfactValue.Heal:
                value = 1;
                break;

            case ImfactValue.Damage:
                value = -1;
                break;
        }

        return value;
    }


}
