using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    public GameObject[] CheckPoints;

    public PlayerController Player;
    public EnvironmentSoundManager SoundManager;

    private int numberOfCheckPoints;
    private int currentCheckPointCompleted = 0;

    public void resetCheckPoints()
    {
        foreach (GameObject checkPoint in CheckPoints)
        {
            checkPoint.SetActive(false);
        }

        CheckPoints[0].SetActive(true);

        currentCheckPointCompleted = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (currentCheckPointCompleted + 1 < numberOfCheckPoints)
            {
                CheckPoints[currentCheckPointCompleted].SetActive(false);
                currentCheckPointCompleted++;
                CheckPoints[currentCheckPointCompleted].SetActive(true);

                SoundManager.playCheckPoint();
            }
            else
            {
                CheckPoints[currentCheckPointCompleted].SetActive(false);
                currentCheckPointCompleted++;
            }
        }
    }

    void Start()
    {
        numberOfCheckPoints = CheckPoints.Length;
    }

    void Update()
    {
        if (numberOfCheckPoints == currentCheckPointCompleted && !Player.hasFinished())
        {
            Player.endRace();
            SoundManager.playVictory();
        }   
    }
}
