using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class SellMagicList : MonoBehaviour
{
    public UnitSkillData skillData;
    public Sprite btnOffSprite;

    private bool bSell;
    private Image thumbnail;
    private TextMeshProUGUI text;
    private Image btnImg;

    public delegate void SellSkillEvent(UnitSkillData skillData);
    public event SellSkillEvent sellSkillEvent;


    private void Awake()
    {
        thumbnail = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        btnImg = transform.GetChild(2).GetComponent<Image>();
        bSell = false;

    }

    private void Start()
    {
        SetThumbnail();
        SetText();

        if(skillData.bHas)
        {
            Debug.Log(skillData);
            bSell = true;
            thumbnail.color = new Color(0, 0, 0, 0.7f);
            btnImg.sprite = btnOffSprite;
        }
    }


    private void SetThumbnail()
    {
        thumbnail.sprite = skillData.thumbnail;
    }

    private void SetText()
    {
        text.SetText("Name : " + skillData.skillName + "    " + "SkilType : " + skillData.skillType + "    " + "Skill Range : " + skillData.targetType + "\n" +
            "SkillValue : " + skillData.skillValue.ToString() + "    " + "CoolTime : " + skillData.coolTime.ToString() + "    " + "Price : " + skillData.price.ToString());
    }


    public void BuyMagic()
    {
        if(CoinSystem.coinCnt() >= skillData.price && !bSell)
        {
            bSell = true;
            skillData.bHas = true;
            thumbnail.color = new Color(0, 0, 0, 0.7f);
            btnImg.sprite = btnOffSprite;
            DelegateSkillSellEvent();
        }
    }

    private void DelegateSkillSellEvent()
    {
        sellSkillEvent?.Invoke(skillData);
    }

}
