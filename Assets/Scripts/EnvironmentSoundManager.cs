using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSoundManager : MonoBehaviour
{
    public AudioSource Crash;
    public AudioSource CheckPoint;
    public AudioSource PickUp;
    public AudioSource Victory;

    public void playCrash()
    {
        Crash.Play();
    }

    public void playCheckPoint()
    {
        CheckPoint.Play();
    }

    public void playPickUp()
    {
        PickUp.Play();
    }

    public void playVictory()
    {
        Victory.Play();
    }
}
