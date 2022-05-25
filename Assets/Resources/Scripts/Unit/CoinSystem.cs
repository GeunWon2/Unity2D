using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CoinSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public UnitCore player;
    public static Func<int> coinCnt;

    private void Start()
    {
        coinCnt = () => { return player.data.coin; };
        InitCoin(player.data.coin);
        
    }

    private void InitCoin(int newCoin)
    {
        SetText(newCoin.ToString());
    }

    public void SetCoin(int newCoin)
    {
        player.data.coin += newCoin;
    }

    public int GetCoin()
    {
        return player.GetCoin();
    }

    public void ChangeCoin(int newValue)
    {
        SetCoin(newValue);
        SetText(GetCoin().ToString());
    }


    public void ChangeCoin(UnitSkillData skilldata)
    {
        SetCoin(-skilldata.price);
        SetText(GetCoin().ToString());
    }

    public void SetText(string nweText)
    {
        text.SetText(nweText);
    }


}
