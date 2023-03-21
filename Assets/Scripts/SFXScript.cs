using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public AudioSource birdJumpSound;
    public AudioSource birdHitSound;
    public AudioSource backgroundMusic;

    public void playBirdJumpSound()
    {
        birdJumpSound.Play();
    }

    public void playBirdHitSound()
    {
        birdHitSound.Play();
    }

    public void playBackgroundMusic(bool active)
    {
        if (active)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Stop();
        }
    }
}
