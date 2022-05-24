using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UnitExp : MonoBehaviour
{
    [SerializeField] private int exp;
    [SerializeField] private int Level;

    public UnityEvent initExp;
    public UnityEvent<int> changeExp;
    public UnityEvent<string> LevelTextChange;
    public UnityEvent<int> LevelUpHP;

    public void SetupEXP(int playerLevel, int playerExp)
    {
        Level = playerLevel;
        exp = playerExp;
        initExp.Invoke();
        LevelTextChange?.Invoke("LV. " + Level.ToString());
    }

    public int GetLevel()
    {
        return Level;
    }

    public void ChangeEXP(int point)
    {
        exp += point;

        if (exp >= 100)
        {
            exp -= 100;
            Level++;
            LevelTextChange?.Invoke("LV. " + Level.ToString());
            LevelUpHP?.Invoke(100);
        }

        changeExp.Invoke(exp);

    }
}
