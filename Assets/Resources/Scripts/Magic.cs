using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Magic : MonoBehaviour
{
    [HideInInspector] public static Func<int,bool> fire;
    [HideInInspector] public static Func<int> hit;


    public List<MagicSkill> testMagicList = new();

    private SpriteRenderer magicImage;
    private bool bCrash;
    private int totalDamage;
    private Vector3 originPosition;
    private int magicDamage;
    private Queue<MagicSkill> castingMagicList = new();
    private bool bCasting;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        magicImage = GetComponent<SpriteRenderer>();
        MagicListSet();
        originPosition = transform.position;
        bCasting = false;
        fire = (int x) => { Casting(x); return bCasting; };
        hit = () => { return totalDamage; };
        bCrash = false;
        totalDamage = 0;
    }


    private void Casting(int playerPower)
    {
        bCasting = false;
        if (!bCrash && (castingMagicList.Count != 0) && (EnemyWave.enemyCnt() != 0))
        {
            if (transform.position.x == originPosition.x)
            {
                bCasting = true;
                MagicSkill temp = castingMagicList.Peek();
                totalDamage = temp.Damage + playerPower;
                magicImage.sprite = temp.MagicEffect;
            }
            transform.position += Vector3.right * 0.01f;
        }
        else
        {
            magicImage.sprite = null;
            transform.position = originPosition;
            bCrash = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bCrash = true;
        StartCoroutine(SkillCoolTime(castingMagicList.Dequeue()));
    }

    public void MagicListSet()
    {
        int magicCnt = testMagicList.Count;

        for(int i = 0; i < magicCnt; i++)
        {
            castingMagicList.Enqueue(testMagicList[i]);
        }     
    }


    IEnumerator SkillCoolTime(MagicSkill magic)
    {
        yield return new WaitForSeconds(magic.CoolTime);
        Debug.Log(magic.SkillName);
        castingMagicList.Enqueue(magic);
    }


}
