using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Magic : MonoBehaviour
{
    public List<MagicSkill> testMagicList = new List<MagicSkill>();

    public UnityEvent<Enemy> KillEnemy;

    private Queue<MagicSkill> castingMagicList = new Queue<MagicSkill>();

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MagicListSet();
    }


    public void Casting(int playerPower, Enemy target)
    {
        if (castingMagicList.Count != 0 && !target.bDead)
        {
            MagicSkill temp = castingMagicList.Peek();
            target.Hurt(playerPower+temp.Damage);
            StartCoroutine(SkillCoolTime(castingMagicList.Dequeue()));
        }
        else if(target.bDead == true)
        {
            KillEnemy.Invoke(target);
        }

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
