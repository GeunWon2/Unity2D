using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitSkillSystem : MonoBehaviour
{
    public UnitSkill[] skills;

    [SerializeField] private List<int> skillList;

    private bool bSkillCastingReady;
    private bool bSkillActive;

    private void Awake()
    {
        skillList = new();
        InitSkills();
    }

    private void InitSkills()
    {
        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].SetID(i);
            skills[i].SetTimer();
        }
    }

    public void StartSkillsCooldown()
    {
        bSkillCastingReady = true;
        bSkillActive = false;

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].StartCooldownSet();
        }

    }

    public void SkillListAdd(int ID)
    {
        skillList.Add(ID);
        CastingCheck();
    }

    private void CastingCheck()
    {
        if(skillList.Count > 0)
        {
            if(!bSkillActive)
            {
                if(bSkillCastingReady)
                {
                    StartCasting();
                    bSkillActive = true;
                }
            }
        }
    }

    private void StartCasting()
    {
        int castingID = skillList[0];
        skills[castingID].StartCasting();
        skillList.RemoveAt(0);
    }

    public void CastingFinish()
    {
        bSkillActive = false;
        CastingCheck();
    }

    public void StopCasting()
    {
        //skillList.Clear();
        bSkillCastingReady = false;

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].StopCasting();
        }
    }



}
