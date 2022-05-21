using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetSystem : MonoBehaviour
{
    public List<UnitCore> targetList;

    public void TargetAdd(List<UnitCore> target)
    {
        targetList.Clear();

        for(int i = 0; i < target.Count; i++)
        {
            targetList.Add(target[i]);
        }
    }


    //public void TargetAdd(UnitCore target)
    //{
    //    targetList.Clear();

    //    targetList.Add(target);

    //}


    public void TaretDelete(UnitCore target)
    {
        targetList.Remove(target);
    }


    public List<UnitCore> TargetRange(TargetType targetType)
    {
        List<UnitCore> target = new();

        if(targetList.Count <= 0)
        {
            return target;
        }

        switch (targetType)
        {
            case TargetType.Single:
                int randomUnit = Random.Range(0, target.Count);
                target.Add(targetList[randomUnit]);
                break;
            case TargetType.Multi:
                target = targetList;
                break;
        }

        return target;
    }


    public UnitCore GetSingleTarget()
    {
        int randomUnit = Random.Range(0, targetList.Count);
        return targetList[0];
    }

    public List<UnitCore> GetAllTarget()
    {
        return targetList;
    }



}
