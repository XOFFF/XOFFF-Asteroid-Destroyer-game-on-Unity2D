using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControls : MonoBehaviour
{
    public AudioSource bonus;
    public AudioSource crash;
    public AudioSource shoot;
    public AudioSource gameOver;

    public AudioSource BonusSound()
    {
        return bonus;
    }

    public AudioSource CrashSound()
    {
        return crash;
    }

    public AudioSource ShootSound()
    {
        return shoot;
    }

    public AudioSource GameOverSound()
    {
        return gameOver;
    }
}
