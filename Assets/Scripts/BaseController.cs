using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public PlayerController player;

    public GameObject Shell;
    public GameObject Mushroom;
    public Transform PickUpSpawnPlatform;

    GameObject randomizeItem()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            GameObject shell = Shell;
            shell.GetComponent<ShellController>().player = player;
            shell.GetComponent<ShellController>().kart = gameObject.transform.parent.GetComponent<KartMovement>();
            shell.GetComponent<ShellController>().PickUpSpawnPlatform = PickUpSpawnPlatform;
            return shell;
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
