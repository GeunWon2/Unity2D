using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UnitPointSystem : MonoBehaviour
{
    [SerializeField]private int HP;

    public UnityEvent<int> changeHP;
    public UnityEvent HPZeroEvent;

    //public delegate void HPChangeEventHandler(int HPAmount);
    //public event HPChangeEventHandler HPChangedEvent;



    public void SetupHP(int maxHP)
    {
        HP = maxHP;
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
        //DelegateEventHPChanged();
    }


    //private void DelegateEventHPChanged()
    //{
    //    HPChangedEvent?.Invoke(HP);
    //}


}
