using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotList : MonoBehaviour
{
    public QuickSlot[] slot;
    public UnitSkill[] tempSkill;
    public UnitSkillSystem playerSkill;

    private int cnt;
    private void Start()
    {
        cnt = 0;
    }


    public void SlotSet(UnitSkillData skilldata)
    {
        if (cnt >= 2)
            return;

        slot[cnt].skill.data = skilldata;
        tempSkill[cnt].data = skilldata;

        slot[cnt].ChangeSkill(skilldata);

        AddPlayerSkill();
        cnt++;
    }

    public void AddPlayerSkill()
    {

        if(tempSkill[0].data!= null)
        {
            playerSkill.AddSkills(tempSkill[0]);
        }

        if (tempSkill[1].data != null)
        {
            playerSkill.AddSkills(tempSkill[1]);

        }

    }


}
