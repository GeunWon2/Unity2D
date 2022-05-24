using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PotionSlot : MonoBehaviour
{
    public Image img;

    public CoinSystem coin;
    public UnitHealthSystem hp;

    private bool bClick = false;

    public void ClikSlot()
    {
        if (!bClick && (coin.GetCoin() >= 50) 
            && (hp.GetHP() < 100) && (hp.GetHP() > 0))
        {
            coin.ChangeCoin(-50);
            hp.ChangeHP(20);
            StartCoroutine(ClickCorutine());
        }
    }

    IEnumerator ClickCorutine()
    {
        bClick = true;
        img.fillAmount = 0;
        
        while(img.fillAmount < 1)
        {
            img.fillAmount += Time.deltaTime/5;

            yield return new WaitForFixedUpdate();
        }

        bClick = false;
    }


}
