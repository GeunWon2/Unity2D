using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return sInstance; } }
    private static GameManager sInstance;
    private void Awake()
    {
        sInstance = this;
        DontDestroyOnLoad(this.gameObject);     

    }


    public Player player;
    public EnemyWave enemyWave;
    public PositionScroller stage;

    private Player playerStateVar;
    private EnemyWave enemyVar;

    private void Start()
    {
        playerStateVar = player.GetComponent<Player>();
        enemyVar = enemyWave.GetComponent<EnemyWave>();
    }



    private void Update()
    {
 
        if (enemyVar.WaveClear())
        {
            playerStateVar.PlayerState(EPlayerState.Run);

            if (!(stage.GetComponent<PositionScroller>().NextStage(true)))
            {
                enemyVar.EnemyReset();
                playerStateVar.PlayerState(EPlayerState.Idle);
            }
        }
        else
        {
            playerStateVar.PlayerState(EPlayerState.Attack);
        }


    }

}
