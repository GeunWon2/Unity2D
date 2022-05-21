using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTimer
{
    private float timerTime;
    private float coolTime;

    public float GetTimertime()
    {
        return timerTime;
    }

    public float GetCooltime()
    {
        return coolTime;
    }



    public CoolTimer(float coolTime)
    {
        Reset(coolTime);
    }


    public void Init()
    {
        timerTime = 0;
    }

    public void Reset(float coolTime)
    {
        Init();
        this.coolTime = coolTime;
    }

    public void UpdateTime()
    {
        timerTime += Time.deltaTime;
    }
    
    public bool Elapsed()
    {
        return TolerantGreaterThanOrEquals(timerTime, coolTime);
    }


    public void Finish()
    {
        timerTime = coolTime;
    }



    /**
    * Returns whether or not a == b
    */
    public static bool TolerantEquals(float a, float b)
    {
        return Mathf.Approximately(a, b);
    }

    /**
     * Returns whether or not a >= b
     */
    public static bool TolerantGreaterThanOrEquals(float a, float b)
    {
        return a > b || TolerantEquals(a, b);
    }

    /**
     * Returns whether or not a <= b
     */
    public static bool TolerantLesserThanOrEquals(float a, float b)
    {
        return a < b || TolerantEquals(a, b);
    }




}
