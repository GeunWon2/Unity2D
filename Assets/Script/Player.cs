using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Attack = 1,
    Hurt = 2,
    Run = 3,
    Die = 4

}

public class Player : MonoBehaviour
{
   [SerializeField] private int MaxHP;
   [SerializeField] private int HP;
   [SerializeField] private int MP;
   [SerializeField] private int MaxMP;
   [SerializeField] private int damage;
   [SerializeField] private bool bMagicCasting;
    private bool bDead;
    private Animator anim;


    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (!bDead)
        {
            if (bMagicCasting)
            {
                if (Magic.fire(damage, bMagicCasting))
                {
                    PlayerAnimation(PlayerState.Attack);
                }
            }

        }
        else
        {
            bMagicCasting = false;
        }

    }

    private void Init()
    {      
        anim = GetComponent<Animator>();
        bDead = false;
        MaxHP = 100;
        HP = MaxHP;
        MaxMP = 100;
        MP = MaxMP;
        damage = 1;
        bMagicCasting = true;
    }

    private void PlayerAnimation(PlayerState playerState)
    {
        switch(playerState)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Attack:
                 anim.SetTrigger("attack");
                break;
        }
    }



}
