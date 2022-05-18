using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Unit/Info", order = 1)]
public class UnitInfo : ScriptableObject
{
    public string unitName;
    public Sprite unitSprite;
    [Range (0, 100)]public int maxHP;
}
