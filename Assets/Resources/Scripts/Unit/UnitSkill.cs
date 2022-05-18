using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
public enum SkillActionType
{
    Automatic,
    ManualButton
}

public class UnitSkill : MonoBehaviour
{
    public UnitSkillData data;
    public SkillActionType playType;

    private int No;

    public bool bCooldownActive;
    public bool bSkillReady;

    public PlayableDirector showSkill;

    public UnityEvent<int> skillReady;
    public UnityEvent<int, TargetType> skillToTarget;
    public UnityEvent<int> skillFinish;

    //public delegate void SkillUIHandler(float newCoolTimeAmount);
    //public event SkillUIHandler SkillUIChange;

    public void Numbering(int newNo)
    {
        No = newNo;
    }

    public void Casting()
    {
        bCooldownActive = true;
        bSkillReady = false;
    }

    private void Update()
    {
        if(bCooldownActive)
        {
            StartCoroutine(CoolDown());
        }
    }


    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(data.coolTime);
        EndCoolDown();
    }


    public void EndCoolDown()
    {
        bCooldownActive = false;
        bSkillReady = true;
        ReadySkill();
    }

    public void ReadySkill()
    {
        if (bSkillReady)skillReady.Invoke(No);
    }

    public void StopSkill()
    {
        bCooldownActive = false;
        bSkillReady = false;
    }


    public void CastingBegin()
    {
        showSkill.Play();
        bSkillReady = false;
    }

    public void CastingTarget()
    {
        skillToTarget.Invoke(data.GetValue(), data.targetType);
    }

    public void CastingFinish()
    {
        bCooldownActive = true;
        skillFinish.Invoke(No);
    }




}
