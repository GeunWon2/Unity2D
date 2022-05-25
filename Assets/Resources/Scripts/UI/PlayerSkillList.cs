using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerSkillList : MonoBehaviour
{
    public PlayerSkillListSlot listSlot;
    public Transform parent;

    public bool bClick;
    public UnityEvent<UnitSkillData> setSlot;


    private List<UnitSkill> hasSkillList;
    private UnitSkillData[] skillsData;


    private void Awake()
    {
        skillsData = Resources.LoadAll<UnitSkillData>("Data/SkillData/");

        hasSkillList = new();

        Init();
    }

    public void SetVisible()
    {
        if (bClick)
            this.gameObject.SetActive(true);
    }


    private void Init()
    {

        for (int i = 0; i < skillsData.Length; i++)
        {
            if (skillsData[i].bHas)
            {
                UnitSkill temp = gameObject.AddComponent<UnitSkill>();
                temp.data = skillsData[i];
                hasSkillList.Add(temp);
            }
        }

        for (int i = 0; i < hasSkillList.Count; i++)
        {
            PlayerSkillListSlot Instance = Instantiate(listSlot, parent);
            Instance.skilldata = hasSkillList[i].data;
            Instance.GetComponent<Image>().sprite = hasSkillList[i].data.thumbnail;
            Instance.quikPostData += PostQuickData;
        }
    }

    public void BuySkill(UnitSkillData buySkill)
    {
        UnitSkill tempSkill = gameObject.AddComponent<UnitSkill>();
        tempSkill.data = buySkill;
        int cnt = hasSkillList.Count;
        hasSkillList.Add(tempSkill);

        PlayerSkillListSlot Instance = Instantiate(listSlot, parent);
        Instance.skilldata = hasSkillList[cnt].data;
        Instance.GetComponent<Image>().sprite = hasSkillList[cnt].data.thumbnail;
        Instance.quikPostData += PostQuickData;


    }


    public void PostQuickData(UnitSkillData skillData)
    {
        setSlot?.Invoke(skillData);
    }



}
