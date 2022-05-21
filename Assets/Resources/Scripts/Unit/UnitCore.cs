using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCore : MonoBehaviour
{
    public UnitData data;
    public UnitPointSystem HP;

    public UnitTargetSystem target;
    public UnitSkillSystem skill;
    public UnitAnim anim;
        
    private bool bAlive;

    public delegate void UnitDiedEventHandler(UnitCore unit);
    public event UnitDiedEventHandler UnitDiedEvent;

    private void Start()
    {
        SetAlive();
        StartGame();
    }

    public void SetAlive()
    {
        HP.SetupHP(data.maxHP);
        bAlive = true;
    }

    public bool GetAlive()
    {
        return bAlive;
    }


    public void StartGame()
    {
        skill.StartSkillsCooldown();
    }

    public void EndGame()
    {
        skill.StopCasting();
    }

    public void TargetAdd(List<UnitCore> targets)
    {
        this.target.TargetAdd(targets);
    }



    public void TargetDelete(UnitCore target)
    {
        this.target.TaretDelete(target);
    }

    public void CastingTarget(int skillValue, TargetType targetType)
    {
        List<UnitCore> targets = target.TargetRange(targetType);

        if(targets.Count > 0)
        {
            for(int i = 0; i < targets.Count; i++)
            {
                targets[i].CastingAffect(skillValue);
            }
        }

    }

    public void CastingAffect(int skillValue)
    {
        if(bAlive)
        {
            HP.ChangeHP(skillValue);
            anim.Hit();
        }
    }

    public int GetHP()
    {
        return HP.GetHP();
    }


    public void UnitDie()
    {
        bAlive = false;
        skill.StopCasting();
        anim.Die();

        DelegateEventUnitDie();
    }

    private void DelegateEventUnitDie()
    {
        UnitDiedEvent?.Invoke(this);
    }
}
