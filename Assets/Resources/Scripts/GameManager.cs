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


    private void Start()
    {
        player.StartLevel();
    }

}
