using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Magic : MonoBehaviour
{
    [HideInInspector] public static Func<int, bool, bool> fire;
    public List<MagicSkill> testMagicList = new();

    private SpriteRenderer magicImage;
    private bool bCrash;
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
        fire = (int x, bool b) => { Casting(x,b); return bCasting; };
        bCrash = false;
    }


    private void Casting(int playerPower, bool bPlayerCasting)
    {
        if (bPlayerCasting)
        {
            if (!bCrash && (castingMagicList.Count != 0))
            {
                if (transform.position.x == originPosition.x)
                {
                    bCasting = true;
                }
                else
                {
                    bCasting = false;
                }

                transform.position += Vector3.right * 0.01f;
                magicImage.sprite = castingMagicList.Peek().MagicEffect;
            }
            else
            {
                magicImage.sprite = null;
                transform.position = originPosition;
                bCrash = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bCrash = true;
        StartCoroutine(SkillCoolTime(castingMagicList.Dequeue()));
    }

    private void MagicListSet()
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
