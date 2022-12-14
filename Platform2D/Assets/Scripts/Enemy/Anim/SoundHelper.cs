using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelper : MonoBehaviour
{
    public AudioSource walkSFX;
    
    public void PlayAudioWalk()
    {
        if (walkSFX != null) walkSFX.Play();
    }

}
