using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelperforPlayer : MonoBehaviour
{
    public AudioSource walkSFX;
    public AudioSource jumpSFX;
    public AudioSource deathSFX;

    public void PlayWalkSFX()
    {
        if (walkSFX != null) walkSFX.Play();
    }
    public void PlayJumpSFX()
    {
        if (jumpSFX != null) jumpSFX.Play();
    }
    public void PlayDeathSFX()
    {
        if (deathSFX != null) deathSFX.Play();
    }
}
