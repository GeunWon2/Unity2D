using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EUnitType
{
    Player,
    Enemy
}



[CreateAssetMenu(fileName = "UnitData", menuName = "UnitData")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public int maxHP;
    public int coin;
    public int exp;
    public int level;
    public EUnitType unitType;

}
