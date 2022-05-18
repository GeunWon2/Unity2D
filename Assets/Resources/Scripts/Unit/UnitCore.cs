using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCore : MonoBehaviour
{
    [Header("Info")]
    public UnitInfo info;

    [Header("HP Set")]
    public UnitHealthSystem HP;
    private bool bUnitAlive;

    [Header("Target Set")]
    public UnitTargetingSystem target;

    [Header("Skill Set")]
    public UnitSkillSystem skill;

    [Header("Anim Set")]
    public UnitAnimationSystem anim;

    public bool bInit;

    public delegate void UnitDiedEventHandler(UnitCore unit);
    public event UnitDiedEventHandler unitDiedEvent;

    private void Start()
    {
        Init();
        Started();
    }

    public void SetTargets(List<UnitCore> units)
    {
        target.TargetInit(units);
    }

    public void RemoveTargets(UnitCore unit)
    {
        target.RemoveTarget(unit);
    }


    public void Init()
    {
        HP.InitHP(info.maxHP);
        bUnitAlive = true;
    }

    public void Started()
    {
        skill.SkillsCasting();
    }

    public void Ened()
    {
        skill.StopSkillSystem();
    }

    public void SkillAffect(int skillValue, TargetType targetType)
    {
        List<UnitCore> targets = target.TargetingFilter(targetType);

        if(targets.Count > 0)
        {
            for(int i = 0; i < targets.Count; i++)
            {
                targets[i].ReciveSkillValue(skillValue);
            }
        }

    }

    public void ReciveSkillValue(int skillValue)
    {
        if(bUnitAlive)
        {
            HP.ChangeHP(skillValue);
            anim.AnimState(animState.Hit);

        }
    }

    public int GetHP()
    {
        return HP.GetHP();
    }

    public void UnitDied()
    {
        bUnitAlive = false;
        skill.StopSkillSystem();
        anim.AnimState(animState.Die);


        DelegateDied();
    }

    private void DelegateDied()
    {
        unitDiedEvent?.Invoke(this);
    }

}
