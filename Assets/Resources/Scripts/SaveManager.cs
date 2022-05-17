using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Singleton
    public static SaveManager Instance { get { return sInstance; } }
    private static SaveManager sInstance;

    private void Start()
    {
        sInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
}
