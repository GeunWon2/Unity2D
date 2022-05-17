using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance { get { return sInstance; } }
    private static SoundManager sInstance;

    private void Start()
    {
        sInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
}
