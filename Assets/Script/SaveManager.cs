using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Singleton
    private static SaveManager sInstance;

    public static SaveManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("SaveManager");
                sInstance = newGameObject.AddComponent<SaveManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
}
