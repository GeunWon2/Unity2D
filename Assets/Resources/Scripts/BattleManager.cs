using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BattleManager : MonoBehaviour
{
    public List<UnitCore> player;
    public EnemyWave wave;
    private List<UnitCore> enemy;

    public bool bAutoTargets = true;

    private List<UnitCore> playerAlive;
    private List<UnitCore> enemyAlive;

    public UnityEvent NextStaget;
    public UnityEvent<int> GetCoin;
    public UnityEvent<int> GetExp;


    private void Start()
    {
        SetupUnits();
        StartBattle();
    }

    public void ReStart()
    {
        SetupUnits();
        StartBattle();
    }


    private void SetupUnits()
    {
        CreateAliveUnits();

        if (bAutoTargets)
        {
            AutoAddPlayerTarget();
        }

    }

    public void StartBattle()
    {
        for (int i = 0; i < playerAlive.Count; i++)
        {
            playerAlive[i].StartGame();
        }

        for (int i = 0; i < enemyAlive.Count; i++)
        {
            enemyAlive[i].StartGame();
        }
    }
  

    private void AutoAddPlayerTarget()
    {
        
        for (int i = 0; i < playerAlive.Count; i++)
        {
            playerAlive[i].TargetAdd(enemyAlive);
        }

        for (int i = 0; i < enemyAlive.Count; i++)
        {
            enemyAlive[i].TargetAdd(playerAlive);
        }
    }

    private void CreateAliveUnits()
    {
        
        playerAlive = new();

        for (int i = 0; i < player.Count; i++)
        {
            playerAlive.Add(player[i]);
            if (!player[i].GetAlive())
            {
                playerAlive[i].SetAlive();
            }
            playerAlive[i].UnitDiedEvent += UnitDied;
        }


        enemyAlive = new();

        enemy = wave.GetEnemyList();

        for(int i = 0; i < enemy.Count; i++)
        {
            enemyAlive.Add(enemy[i]);
            enemyAlive[i].SetAlive();
            enemyAlive[i].UnitDiedEvent += UnitDied;
        }

    }

    private void UnitDied(UnitCore dieUnit)
    {
        UnitsRemove(dieUnit);
    }

    private void UnitsRemove(UnitCore dieUnit)
    {
        CheckBattle();

        for(int i = 0; i < playerAlive.Count; i++)
        {
            if(dieUnit == playerAlive[i])
            {
                playerAlive[i].UnitDiedEvent -= UnitDied;
                playerAlive.RemoveAt(i);
                RemoveEnemyTargets(dieUnit);
            }
        }

        for (int i = 0; i < enemyAlive.Count; i++)
        {
            if (dieUnit == enemyAlive[i])
            {
                enemyAlive[i].UnitDiedEvent -= UnitDied;
                enemyAlive.RemoveAt(i);
                RemovePlayerTargets(dieUnit);
                PlayerGetReward(dieUnit);
            }
        }

        CheckBattle();
    }

    private void PlayerGetReward(UnitCore dieUnit)
    {
        GetCoin?.Invoke(dieUnit.GetCoin());
        GetExp?.Invoke(dieUnit.GetExp());
    }



    private void RemovePlayerTargets(UnitCore dieUnit)
    {
       for(int i = 0; i < playerAlive.Count; i++)
        {
            playerAlive[i].TargetDelete(dieUnit);
        }
    }

    private void RemoveEnemyTargets(UnitCore dieUnit)
    {
        for (int i = 0; i < enemyAlive.Count; i++)
        {
            enemyAlive[i].TargetDelete(dieUnit);
        }
    }

    private void CheckBattle()
    {
        if(playerAlive.Count == 0)
        {
            SetBattleDefeat();
        }

        if(enemyAlive.Count == 0)
        {
            SetBattleVictory();
        }
    }

    private void SetBattleVictory()
    {
        StopPlayer(playerAlive);
        NextStaget.Invoke();
    }

    private void SetBattleDefeat()
    {
        StopPlayer(playerAlive);
    }

    private void StopPlayer(List<UnitCore> playerUnit)
    {
        for(int i = 0; i < playerUnit.Count; i++)
        {
            playerUnit[i].EndGame();
        }
    }





}
