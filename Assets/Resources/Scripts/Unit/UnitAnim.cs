using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnim : MonoBehaviour
{
    public Animator anim;

    public void Hit()
    {
        anim.SetTrigger("Hit");
    }

    public void Die()
    {
        anim.SetTrigger("Death");
    }

    public void Idle()
    {
        anim.SetTrigger("Idle");
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void RunOn()
    {
        anim.SetBool("isRun", true);
    }

    public void RunOff()
    {
        anim.SetBool("isRun", false);
    }


}
