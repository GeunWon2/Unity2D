using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : MonoBehaviour
{
    private enum SkillType { Launch, Area, Buff }
    [SerializeField]
    private string  skillName;
    private SkillType skillType;
    private int damage;
    private int manaUsage;
    private int coolTime;
    private int magicSpeed;
    private void Init()
    {
        
    }



}
