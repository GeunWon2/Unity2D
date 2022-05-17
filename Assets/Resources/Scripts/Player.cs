using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int MaxHP;
    private int HP;
    private int MP;
    private int MaxMP;
    private int damage;
    private bool bDead;
    private Animator anim;
    private EPlayerState playerState;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {      
        anim = GetComponent<Animator>();
        bDead = false;
        MaxHP = 100;
        HP = MaxHP;
        MaxMP = 100;
        MP = MaxMP;
        playerState = EPlayerState.Attack;
    }


    public void PlayerState(EPlayerState playerState)
    {
        switch(playerState)
        {
            case EPlayerState.Idle:
                if (anim.GetBool("run"))
                {
                    anim.SetBool("run", false);
                }
                break;

            case EPlayerState.Attack:
                if (Magic.fire(damage))
                {
                    anim.SetTrigger("attack");
                }
                break;

            case EPlayerState.Run:
                anim.SetBool("run", true);
                break;


        }
    }


}
