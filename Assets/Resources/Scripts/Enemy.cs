using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public int maxHP;
    public int damage;
    public int coolTime;
    public bool bDead;
    public int level;
    public int No;

    public UnitHealthSystem UnitHp;

    public UnityEvent<int> enemyDied;

    //public delegate void UnitDiedEventHandler(Enemy enemy);
    //public event UnitDiedEventHandler EnemyDiedEvent;

    private void Awake()
    {
        Init();      
    }

    public void Init()
    {
        int temp = EnemyWave.waveLevelNo();

        bDead = false;
        maxHP = 100 + (temp * 10);
        UnitHp.InitHP(maxHP);


        damage = 1;
        coolTime = 5;
        level = 1;
    }

    
    public void Hurt(int damage)
    {
        UnitHp.ChangeHP(-damage);
    }



    public void Died()
    {
        bDead = true;
        Destroy(this.gameObject);

        //DelegateEventEnemyDied();
    }

    //private void DelegateEventEnemyDied()
    //{
    //    if(EnemyDiedEvent != null)
    //    {
    //        EnemyDiedEvent(this);
    //    }
    //}
}
