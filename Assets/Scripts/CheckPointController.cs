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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (currentCheckPointCompleted < numberOfCheckPoints - 1)
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
        numberOfCheckPoints = CheckPoints.Length + 1;
    }

    void Update()
    {
        if (numberOfCheckPoints == currentCheckPointCompleted)
        {
            Player.endRace();
            SoundManager.playVictory();
        }   
    }
}
