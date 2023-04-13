using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundController : MonoBehaviour
{
    public AudioSource EngineIdle;
    public AudioSource EngineRunning;

    public KartMovement KartMovementInfo;

    void Update()
    {
        if (KartMovementInfo.IsKartMoving() && !EngineRunning.isPlaying)
        {
            EngineRunning.Play();
            EngineIdle.Stop();
        }
        else if (!KartMovementInfo.IsKartMoving() && !EngineIdle.isPlaying)
        {
            EngineIdle.Play();
            EngineRunning.Stop();
        }
    }
}
