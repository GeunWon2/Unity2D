using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EPlayerState
{
    Idle,
    Attack,
    Hurt,
    Run,
    Die

}


public class Player : MonoBehaviour
{
    public UnitHealthSystem PlayerHP;
    public UnityEvent<int, Enemy> Attack;
    public UnityEvent<bool> WaveClear;


    private List<Enemy> TargetList = new();

    private int MaxHP;
    private int MP;
    private int MaxMP;
    public int power;
    private Animator anim;
    public bool bClear;

    private void Awake()
    {
        Init();
    }

  
    private void Init()
    {
        bClear = false;
        anim = GetComponent<Animator>();
        MaxHP = 100;
        PlayerHP.InitHP(MaxHP);
        MaxMP = 100;
        MP = MaxMP;
        power = 20;
        bClear = false;

    }

    public void PlayerState(EPlayerState playerState)
    {
        switch(playerState)
        {
            case EPlayerState.Idle:
                anim.SetBool("run", false);
                break;

            case EPlayerState.Attack:
                anim.SetTrigger("attack");             
                break;

            case EPlayerState.Run:
                anim.SetBool("run", true);
                break;

            case EPlayerState.Die:              
                anim.SetTrigger("die");
                break;

            case EPlayerState.Hurt:
                anim.SetTrigger("hurt");
                break;
        }
    }

    public void StartLevel()
    {
        if (TargetList.Count > 0)
        {
            PlayerAttack();
        }
        else if(TargetList.Count <= 0)
        {
            StageClear();
        }
    }



    public void Hurt(int damage)
    {
        PlayerHP.ChangeHP(damage);
        PlayerState(EPlayerState.Hurt);
    }

    public void PlayerDie()
    {
        PlayerState(EPlayerState.Die);
    }

    public void PlayerAttack()
    {
        PlayerState(EPlayerState.Attack);
        Attack.Invoke(power,TargetList[0]);
    }

    public void AddTarget(List<Enemy> enemies)
    {
        TargetList.Clear();

        for(int i = 0; i < enemies.Count; i++)
        {
            TargetList.Add(enemies[i]);
        }      
    }

    public void RemoveTarget(Enemy enemy)
    {
        TargetList.Remove(enemy);
    }


    public List<Enemy> TargetingFilter(TargetType targetingType)
    {
        List<Enemy> filterEnemy = new();

        if (TargetList.Count <= 0)
        {
            return filterEnemy;
        }

        switch (targetingType)
        {
            case TargetType.SingleTarget:
                filterEnemy.Add(TargetList[0]);
                break;

            case TargetType.MultiTarget:
                filterEnemy = TargetList;
                break;
        }

        return filterEnemy;
    }


    public Enemy GetSingleTarget()
    {
        return TargetList[0];
    }

    public List<Enemy> GetAllTarget()
    {
        return TargetList;
    }


    public void StageClear()
    {
        PlayerState(EPlayerState.Run);
        bClear = true;
        WaveClear.Invoke(bClear);
    }

    public void StageChangeComplete()
    {
        bClear = false;
        PlayerState(EPlayerState.Idle);
    }

}
