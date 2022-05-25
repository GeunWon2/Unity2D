using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkillShop : MonoBehaviour
{
    public UnitSkillSystem skillList;
    public Transform parent;
    public SellMagicList sellSlot;

    public UnityEvent<UnitSkillData> buySkill;

    private UnitSkillData[] resource;
    private void Awake()
    {
        resource = Resources.LoadAll<UnitSkillData>("Data/SkillData/");

    }

    private void Start()
    {

        for(int i = 0; i < resource.Length; i++)
        {
            if(resource[i].bHas == false)
            {
                SellMagicList Instance = Instantiate(sellSlot, parent);
                Instance.skillData = resource[i];
                Instance.sellSkillEvent += BuySkill;
            }
        }

        
    }


    public void BuySkill(UnitSkillData data)
    {
        buySkill?.Invoke(data);
    }


}
