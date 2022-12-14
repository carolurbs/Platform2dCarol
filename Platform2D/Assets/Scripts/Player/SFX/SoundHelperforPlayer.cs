using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelperforPlayer : MonoBehaviour
{
    public AudioSource walkSFX;
    public AudioSource jumpSFX;

    public void PlayWalkSFX()
    {
        if (walkSFX != null) walkSFX.Play();
    }
    public void PlayJumpSFX()
    {
        if (jumpSFX != null) jumpSFX.Play();
    }
  
}
