using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum animState
{
    Idle,
    Hit,
    Die,
    Attack,
    Run
}


public class UnitAnimationSystem : MonoBehaviour
{
    public Animator unitAnim;

    public void AnimState(animState state)
    {
        switch(state)
        {
            case animState.Idle:
                unitAnim.SetTrigger("Idle");
                break;
            case animState.Attack:
                unitAnim.SetTrigger("Attack");
                break;
            case animState.Hit:
                unitAnim.SetTrigger("Hit");
                break;
            case animState.Run:
                unitAnim.SetBool("Run", true);
                break;
            case animState.Die:
                unitAnim.SetTrigger("Die");
                break;
        }

    }


}
