using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public PlayerController player;

    public GameObject Shell;
    public GameObject Mushroom;

    GameObject randomizeItem()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            return Shell;
        } else
        {
            return Mushroom;
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
