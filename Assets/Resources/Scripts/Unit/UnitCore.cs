using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCore : MonoBehaviour
{
    public UnitData data;
    public UnitHealthSystem HP;

    public UnitTargetSystem target;
    public UnitSkillSystem skill;
    public UnitAnim anim;
        
    private bool bAlive;
    private UnitExp exp;

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

        if(data.unitType == EUnitType.Player)
        {
            exp = GetComponent<UnitExp>();
            exp.SetupEXP(data.level, data.exp);
        }

    }

    public bool GetAlive()
    {
        return bAlive;
    }

    public int GetCoin()
    {
        return data.coin;
    }

    public int GetExp()
    {
        return data.exp;
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
        Destroy(this.gameObject);
    }

    private void DelegateEventUnitDie()
    {
        UnitDiedEvent?.Invoke(this);
    }
}
