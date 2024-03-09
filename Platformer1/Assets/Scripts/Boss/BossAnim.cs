using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    private Animator anim;
    private bool shootFinished;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void IdleAnim()
    {
        anim.SetBool("idle", true);
        anim.SetBool("run", false);
        anim.SetBool("dash", false);
        anim.SetBool("shoot", false);
    }

    public void RunAnim()
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", true);
        anim.SetBool("dash", false);
        anim.SetBool("shoot", false);
    }

    public void DashAnim()
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", false);
        anim.SetBool("dash", true);
        anim.SetBool("shoot", false);
    }

    public void ShootAnim()
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", false);
        anim.SetBool("dash", false);
        anim.SetBool("shoot", true);
    }

    public void ShootFinished()
    {
        shootFinished = true;
    }
    public void ResetShootFinished()
    {
        shootFinished = false;
    }

    public bool CheckShootFinished()
    {
        return shootFinished;
    }
}
