using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform PickUpSpawnPlatform;

    public TextMeshPro TimerText;

    public CheckPointController CheckPointController;

    public GameObject HowTo;

    public Transform Kart;

    private GameObject item;

    private float timer;

    private bool start = false;

    private bool finished = false;

    public void Reset()
    {
        timer = 0;
        start = false;
        finished = false;
        RemoveItem();

        CheckPointController.resetCheckPoints();

        HowTo.SetActive(true);

        Kart.position = new Vector3(0, 0.15f, -2);
        Kart.rotation = new Quaternion(0, 0, 0, 1);
    }

    public bool hasRaceStarted()
    {
        return start;
    }

    public void startRace()
    {
        start = true;
    }

    public void endRace()
    {
        finished = true;
    }

    public bool hasFinished()
    {
        return finished;
    }

    public void RemoveItem()
    {
        item = null;
    }

    public void SetItem(GameObject newItem)
    {
        if (item != null)
        {
            item.GetComponent<DestroyItemController>().DestroyMe();
            item = null;
        }

        Vector3 elevatedAmount = new Vector3(0f, 0.1f, 0f);
        Vector3 elevatedPosition = PickUpSpawnPlatform.transform.position + elevatedAmount;

        item = Instantiate(newItem, elevatedPosition, PickUpSpawnPlatform.transform.rotation, PickUpSpawnPlatform);
    }

    void FixedUpdate()
    {
        if (start && !finished)
        {
            timer += Time.deltaTime;
            TimerText.text = timer.ToString("F2") + " s";
        }
    }
}
