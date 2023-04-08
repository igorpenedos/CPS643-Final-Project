using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEditor.Progress;

public class BaseController : MonoBehaviour
{
    public PlayerController player;

    public GameObject Shell;
    public GameObject Mushroom;
    public Transform PickUpSpawnPlatform;

    GameObject randomizeItem()
    {
        int random = Random.Range(0, 2);
        if (random == 5)
        {
            return Shell;
        } else
        {
            GameObject mushroom = Mushroom;
            mushroom.GetComponent<MushroomController>().player = player;
            mushroom.GetComponent<MushroomController>().kart = gameObject.transform.parent.GetComponent<KartMovement>();
            mushroom.GetComponent<MushroomController>().PickUpSpawnPlatform = PickUpSpawnPlatform;
            return mushroom;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && other.gameObject.GetComponent<Renderer>().isVisible)
        {
            GameObject newItem = randomizeItem();
            player.SetItem(newItem);

            PickUpController pickUp = other.gameObject.GetComponent<PickUpController>();
            pickUp.DestroyAndRespawn();
        }
    }
}
