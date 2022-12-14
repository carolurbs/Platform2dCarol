using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelper : MonoBehaviour
{
    public AudioSource walkSFX;
    public AudioSource attackSFX;
    public AudioSource deathSFX;

    public void PlayAudioWalk()
    {
        if (walkSFX != null) walkSFX.Play();
    }
    public void PlayAudioAtack()
    {
        if (attackSFX != null) attackSFX.Play();
    }
    public void PlayAudioDeath()
    {
        if (deathSFX != null) deathSFX.Play();
    }
}
