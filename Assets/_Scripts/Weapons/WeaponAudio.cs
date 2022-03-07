using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField] 
    private AudioClip shootBullet = null, outOfBulletsClip = null;

    public void PlayShootSound()
    {
        PlayClip(shootBullet);
    }

    public void PlayNoBulletsSound()
    {
        PlayClip(outOfBulletsClip);
    }
}
