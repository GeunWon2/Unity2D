using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyWave : MonoBehaviour
{
    public int waveLevel;
    public GameObject enemyTile;
    public static Func<int> enemyCnt;
    public static Func<int> waveLevelNo;


    private GameObject[] normalEnemyPrefab = null;
    private GameObject[] bossEnemyPrefab = null;


    private void Awake()
    {
        normalEnemyPrefab = Resources.LoadAll<GameObject>("Enemy/Normal");
        bossEnemyPrefab = Resources.LoadAll<GameObject>("Enemy/Boss");
        waveLevel = 1;
        EnemyReset();
    }

    public bool WaveClear()
    {
        if(transform.childCount == 0)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public void EnemyReset()
    {
        waveLevelNo = () => { return waveLevel; };

        int level = waveLevel % 6;
        int bossNo = waveLevel / 6;

        if (level > 0 && level <= 5)
        {
            for (int i = 0; i < level; i++)
            {
                int random = UnityEngine.Random.Range(0, normalEnemyPrefab.Length);
                GameObject instance = Instantiate(normalEnemyPrefab[random], transform);
                instance.transform.position = enemyTile.transform.GetChild(i).transform.position;
            }
        }
        else if(bossNo != 0)
        {
            GameObject instance = Instantiate(bossEnemyPrefab[level + (bossNo - 1)], transform);
            instance.transform.position = enemyTile.transform.GetChild(5).transform.position;
        }
        enemyCnt = () => { return transform.childCount; };
        waveLevel++;
    }


}
