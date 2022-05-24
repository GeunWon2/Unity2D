using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UnitHealthSystem : MonoBehaviour
{
    [SerializeField]private int HP;

    public UnityEvent initHP;
    public UnityEvent<int> changeHP;
    public UnityEvent HPZeroEvent;

    public void SetupHP(int maxHP)
    {
        HP = maxHP;
        initHP.Invoke();
    }

    public int GetHP()
    {
        return HP;
    }

    public void ChangeHP(int point)
    {
        HP += point;

        if(HP <= 0)
        {
            HP = 0;
            HPZeroEvent.Invoke();
        }

        changeHP.Invoke(point);
       
    }





}
