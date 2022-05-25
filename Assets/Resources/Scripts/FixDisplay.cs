using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDisplay : MonoBehaviour
{
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(540, 960, true);
    }
}
