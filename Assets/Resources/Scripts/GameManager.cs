using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<UnitCore> player;
    public List<UnitCore> enemy;

    public bool bAutoTargets = false;

    private List<UnitCore> playerAlive;
    private List<UnitCore> enemyAlive;

    private void Awake()
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
            playerAlive[i].SetAlive();
            playerAlive[i].UnitDiedEvent += UnitDied;
        }


        enemyAlive = new();

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
            }
        }

        CheckBattle();
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
            SetBattleVictor();
        }
    }

    private void SetBattleVictor()
    {
        Debug.Log("Victory");
        StopPlayer(playerAlive);
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
