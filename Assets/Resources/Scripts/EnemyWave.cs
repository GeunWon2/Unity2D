using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EnemyWave : MonoBehaviour
{
    public GameObject enemyTile;
    public static Func<int> waveLevelNo;
    
    public UnityEvent<List<Enemy>> TargetPost;

    private bool bClear;
    private int waveLevel;
    private List<Enemy> EnemyList = new();
    private Enemy[] normalEnemyPrefab;
    private Enemy[] bossEnemyPrefab;

    private void Awake()
    {
        normalEnemyPrefab = Resources.LoadAll<Enemy>("Prefabs/Enemy/Normal");
        bossEnemyPrefab = Resources.LoadAll<Enemy>("Prefabs/Enemy/Boss");
        waveLevel = 1;
        WaveGeneration();
    }


    public void WaveClear(bool bclaer)
    {
        bClear = bclaer;
        Debug.Log("Clear");
        WaveGeneration();
    }

    public void WaveGeneration()
    {
        
        bClear = false;
        EnemyList.Clear();
        waveLevelNo = () => { return waveLevel; };

        int level = waveLevel % 6;
        int bossNo = waveLevel / 6;

        if (level > 0 && level <= 5)
        {
            for (int i = 0; i < level; i++)
            {
                int random = UnityEngine.Random.Range(0, normalEnemyPrefab.Length);
                Enemy instance = Instantiate(normalEnemyPrefab[random], transform);
                instance.transform.position = enemyTile.transform.GetChild(i).transform.position;
                EnemyList.Add(instance);
            }
        }
        else if(bossNo != 0)
        {
            Enemy instance = Instantiate(bossEnemyPrefab[level + (bossNo - 1)], transform);
            instance.transform.position = enemyTile.transform.GetChild(5).transform.position;
            EnemyList.Add(instance);
        }

        TargetPost.Invoke(EnemyList);
        waveLevel++;
    }


    public int GetClearGoal()
    {
        return EnemyList.Count;
    }


}
