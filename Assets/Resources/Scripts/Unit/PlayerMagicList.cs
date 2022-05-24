using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
public class PlayerMagicList : MonoBehaviour
{
    private UnitSkill[] resourceTemp;
    private List<UnitSkill> skillList;
    public UnityEvent<List<UnitSkill>> skillListPost;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        skillList = new();
         resourceTemp = Resources.LoadAll<UnitSkill>("Prefabs/MagicSkill/");

        for (int i = 0; i < resourceTemp.Length; i++)
        {
            UnitSkill instance = Instantiate(resourceTemp[i],transform);
            skillList.Add(instance);
        }

        

        skillListPost?.Invoke(skillList);

    }


}
