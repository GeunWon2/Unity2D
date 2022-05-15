using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int maxHP;
    private int HP;
    private int damage;
    private int coolTime;
    private bool bDead;
    private int level;

    private void Init()
    {
        maxHP = 100;
        HP = maxHP;
        bDead = false;        
    }





}
