using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkillListSlot : MonoBehaviour
{
    public bool bClick;
    public UnitSkillData skilldata;

    public delegate void QuickPostData(UnitSkillData skillData);
    public event QuickPostData quikPostData;

    private void Awake()
    {
        bClick = false;
    }

    public void Click()
    {
        if(!bClick)
         DelegateQuikPostData();
    }



    private void DelegateQuikPostData()
    {
        quikPostData?.Invoke(skilldata);
        GetComponent<Image>().color = new Color(0, 0, 0, 50);
    }
}
