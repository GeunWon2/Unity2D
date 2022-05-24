using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyWave : MonoBehaviour
{
    public GameObject enemyTile;
    public UnityEvent<string> waveUISet;
    //public UnityEvent<List<UnitCore>> TargetPost;

    [SerializeField] private int waveLevel;
    private List<UnitCore> EnemyList = new();
    private UnitCore[] normalEnemyPrefab;
    private UnitCore[] bossEnemyPrefab;

    private void Awake()
    {
        normalEnemyPrefab = Resources.LoadAll<UnitCore>("Prefabs/Enemy/Normal");
        bossEnemyPrefab = Resources.LoadAll<UnitCore>("Prefabs/Enemy/Boss");
        waveLevel = 1;

    }

    private void Start()
    {
        WaveGeneration();
    }


    public void WaveGeneration()
    {

        EnemyList.Clear();
        waveUISet.Invoke("Wave : " + waveLevel.ToString());

        int level = waveLevel % 6;
        int bossNo = waveLevel / 6;

        if (level > 0 && level <= 5)
        {
            for (int i = 0; i < level; i++)
            {
                int random = UnityEngine.Random.Range(0, normalEnemyPrefab.Length);
                UnitCore instance = Instantiate(normalEnemyPrefab[random], transform);
                instance.transform.position = enemyTile.transform.GetChild(i).transform.position;
                EnemyList.Add(instance);
            }
        }
        else if (bossNo != 0)
        {
            UnitCore instance = Instantiate(bossEnemyPrefab[level + (bossNo - 1)], transform);
            instance.transform.position = enemyTile.transform.GetChild(5).transform.position;
            EnemyList.Add(instance);
        }

        //TargetPost.Invoke(EnemyList);
        waveLevel++;
    }


    public int GetClearGoal()
    {
        return EnemyList.Count;
    }


    public List<UnitCore> GetEnemyList()
    {
        return EnemyList;
    }
}
