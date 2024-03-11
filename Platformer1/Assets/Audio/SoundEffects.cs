using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip potato, carrot, chicken, jump, hurt;

    public void PlayPotato()
    {
        src.clip = potato;
        src.Play();
    }
    public void PlayCarrot()
    {
        src.clip = carrot;
        src.Play();
    }
    public void PlayChicken()
    {
        src.clip = chicken;
        src.Play();
    }
    public void PlayJump()
    {
        src.clip = jump;
        src.Play();
    }
    public void PlayHurt()
    {
        src.clip = hurt;
        src.Play();
    }

}
