using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSkillSystem : MonoBehaviour
{
    public UnitSkill[] skills;

    private List<int> skillList;
    private bool bCasting;
    private bool bActive;

    private void Awake()
    {
        skillList = new List<int>();
        Init();
    }

    private void Init()
    {
        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].Numbering(i);
        }
    }

    public void SkillsCasting()
    {
        bCasting = true;
        bActive = false;

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].Casting();
        }
    }

    public void AddCoolDownList(int skillNo)
    {
        skillList.Add(skillNo);
        NextSkill();
    }

    private void NextSkill()
    {
        if(skillList.Count > 0)
        {
            if(!bActive)
            {
                if(bCasting)
                {
                    ShowSkills();
                    bActive = true;
                }
            }
        }
    }

    private void ShowSkills()
    {
        int temp = skillList[0];
        skills[temp].CastingBegin();
        skillList.Remove(0);
    }

    public void SkillListFinish()
    {
        bActive = false;
        NextSkill();
    }

    public void StopSkillSystem()
    {
        skillList.Clear();
        bCasting = false;

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].StopSkill();
        }
    }


}
