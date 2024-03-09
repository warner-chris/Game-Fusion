using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void IdleAnim()
    {
        anim.SetBool("isGrounded", true);
        anim.SetBool("isRunning", false);
        anim.SetBool("isDamaged", false);
    }

    public void RunAnim()
    {
        anim.SetBool("isGrounded", true);
        anim.SetBool("isRunning", true);
        anim.SetBool("isDamaged", false);
    }

    public void JumpAnim()
    {
        anim.SetBool("isGrounded", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isDamaged", false);
    }

    public void HurtAnim()
    {
        anim.SetBool("isDamaged", true);
    }
}
