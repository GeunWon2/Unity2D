using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicSkill")]
public class MagicSkill : ScriptableObject
{
    public string  SkillName;
    [Range(0, 100)] public int Damage;
    [Range(0, 100)] public int CostMP;
    [Range(0, 100)] public int CoolTime;
    [Range(0, 100)] public int Price;
    public Sprite Thumbnail;
    public Sprite MagicEffect;

}
