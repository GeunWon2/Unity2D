using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuickSlot : MonoBehaviour
{
    public UnitSkill skill;

    private Image img;
    private GameObject coolTime;
    private TextMeshProUGUI text;

    private void Awake()
    {
        img = gameObject.transform.GetChild(0).GetComponent<Image>();
        coolTime = gameObject.transform.GetChild(1).gameObject;
        text = coolTime.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (skill.data != null)
        {
            ThumbnailChange();
            skill.skillCooldownChangeEvent += CoolTime;
        }
    }

    public void ChangeSkill(UnitSkillData skillData)
    {
        if (skill.data != null)
        {
            ThumbnailChange();
            skill.skillCooldownChangeEvent += CoolTime;
        }
    }



    public void ThumbnailChange()
    {
        img.sprite = skill.data.thumbnail;
    }


    public void CoolTime(float newTime)
    {
       
        coolTime.SetActive(true);
        coolTime.GetComponent<Image>().fillAmount = 1-newTime;
        text.SetText(((int)(10-(newTime*10))).ToString());

        if (coolTime.GetComponent<Image>().fillAmount == 0)
        {
            coolTime.GetComponent<Image>().fillAmount = 1;
            coolTime.SetActive(false);
        }

    }



}
