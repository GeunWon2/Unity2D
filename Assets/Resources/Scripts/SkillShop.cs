using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShop : MonoBehaviour
{
    public UnitSkill skill;
    public UnitSkill test;
    public UnitSkillSystem skillList;

    public void PostSkillList()
    {
        skill.gameObject.name = test.gameObject.name;
        skill.data = test.data;
        skill.skillTimeline = test.skillTimeline;

        skillList.ADDSkills(skill);
    }


}
