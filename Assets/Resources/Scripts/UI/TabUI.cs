using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabUI : MonoBehaviour
{
    public GameObject[] Panel;
    public Image[] TabBtn;
    public Sprite[] IdleSprite, SelectSprite;
    public int defaultBtnNo = 0;

    private void Start()
    {
        TabClick(defaultBtnNo);
    }

    public void TabClick(int n)
    {
        for(int i = 0; i < Panel.Length; i++)
        {
            Panel[i].SetActive(i == n);
            TabBtn[i].sprite = (i == n) ? SelectSprite[i] : IdleSprite[i];
        }
    }


}
