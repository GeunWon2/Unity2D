using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealthSystem : MonoBehaviour
{
    [SerializeField] private int HP;

    //public UnityEvent<int> HPChangeEvent;
    public UnityEvent HPZeroEvent;

    //UI¿ë
    public delegate void HealthChangeUIHandler(int newHPAmount);
    public event HealthChangeUIHandler HPUIHandler;

    public void InitHP(int maxHP)
    {
        HP = maxHP;
    }

    public void ChangeHP(int affect)
    {
        HP += affect;

        if(HP <= 0)
        {
            HP = 0;
            HPZero();
        }
        //HPChangeEvent.Invoke(affect);
        //HPUIChange();
    }

    public int GetHP()
    {
        return HP;
    }

    private void HPZero()
    {
        HPZeroEvent.Invoke();
    }

    private void HPUIChange()
    {
        HPUIHandler?.Invoke(HP);
    }

}
