using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject gameManager;
    private SoundEffects soundEffectsScript;

    private void Start()
    {
        anim = GetComponent<Animator>();
        soundEffectsScript = gameManager.GetComponent<SoundEffects>();
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
        soundEffectsScript.PlayJump();
        anim.SetBool("isGrounded", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isDamaged", false);
    }

    public void HurtAnim()
    {
        soundEffectsScript.PlayHurt();
        anim.SetBool("isDamaged", true);
    }
}
