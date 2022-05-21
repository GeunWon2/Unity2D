using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnim : MonoBehaviour
{
    public Animator anim;

    public void Hit()
    {
        anim.SetTrigger("hit");
    }

    public void Die()
    {
        anim.SetTrigger("die");
    }

    public void Idle()
    {
        anim.SetTrigger("idle");
    }

    public void Attack()
    {
        anim.SetTrigger("attack");
    }

}
