using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetingSystem : MonoBehaviour
{
    public List<UnitCore> targetUnits;

    public void TargetInit(List<UnitCore> units)
    {
        targetUnits.Clear();

        for(int i = 0; i < units.Count; i++)
        {
            targetUnits.Add(units[i]);
        }
    }

    public void RemoveTarget(UnitCore unit)
    {
        targetUnits.Remove(unit);
    }


    public List<UnitCore> TargetingFilter(TargetType targetingType)
    {
        List<UnitCore> filterUnit = new List<UnitCore>();

        if(targetUnits.Count <= 0)
        {
            return filterUnit;
        }

        switch (targetingType)
        {
            case TargetType.SingleTarget:
                filterUnit.Add(targetUnits[0]);
                break;

            case TargetType.MultiTarget:
                filterUnit = targetUnits;
                break;
        }

        return filterUnit;
    }


    public UnitCore GetSingleTarget()
    {
        return targetUnits[0];
    }

    public List<UnitCore> GetAllTarget()
    {
        return targetUnits;
    }


}
