using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using System;

public class UnitSkill : MonoBehaviour
{
    public enum SkillMode
    {
        Auto,
        Maual
    }

    public UnitSkillData data;
    public SkillMode skillMode;
    public CoolTimer coolTimer;

    public bool bCooldownActive;
    public bool bSkillReady;

    public PlayableDirector skillTimeline;

    public UnityEvent<int> skillReadyInsert;
    public UnityEvent<int, TargetType> targetToSkill;
    public UnityEvent<int> skillCastFinish;

    //public delegate void SkillCooltimeChangeEventHanlder(float cooldownAmount);
    //public event SkillCooltimeChangeEventHanlder skillCooldownChangeEvent;

    //public delegate void SkillReadyEventHandler();
    //public event SkillReadyEventHandler skillReadyEvent;

    private int ID;

    private void Update()
    {
        StartCooldown();
    }

    public void SetID(int newID)
    {
        ID = newID;
    }

    public void SetTimer()
    {
        coolTimer = new CoolTimer(data.coolTime);
    }

    public void StartCooldownSet()
    {
        bCooldownActive = true;
        bSkillReady = false;
    }


    private void StartCooldown()
    {
        if(bCooldownActive)
        {
            coolTimer.UpdateTime();

            if(coolTimer.Elapsed())
            {
                coolTimer.Finish();
                coolTimer.Init();
                SkillCooldownFinish();
                return;
            }

        }
    }

    private void SkillCooldownFinish()
    {
        bCooldownActive = false;
        bSkillReady = true;

        switch (skillMode)
        {
            case SkillMode.Auto:
                SkillCastingListAdd();
                break;
            case SkillMode.Maual:
                break;
        }
    }

    public void SkillCastingListAdd()
    {
       
        if(bSkillReady)
        {
            skillReadyInsert.Invoke(ID);
        }
    }

    public void StartCasting()
    {
        Debug.Log(this.gameObject.name);
        skillTimeline.Play();
        bSkillReady = false;
    }

    public void StopCasting()
    {
        bCooldownActive = false;
        bSkillReady = false;
    }

    public void CastingAffect()
    {
        int value = data.GetValue();
        targetToSkill.Invoke(value, data.targetType);
    }

    public void CastingFinish()
    {
        bCooldownActive = true;
        skillCastFinish.Invoke(ID);
    }




}
