using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP;
    public int HP;
    public int damage;
    public int coolTime;
    public bool bDead;
    public int level;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        int temp = EnemyWave.waveLevelNo();

        maxHP = 100 + (temp * 10);
        HP = maxHP;
        bDead = false;
        damage = 1;
        coolTime = 5;
        level = 1;
    }


    private void Update()
    {

        if (HP <= 0)
        {
            bDead = true;
            Destroy(gameObject);
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == ("Magic"))
        {
            HP -= Magic.hit();
        }
    }



}
