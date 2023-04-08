using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public PlayerController player;
    public KartMovement kart;
    public Transform PickUpSpawnPlatform;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Camera"))
        {
            kart.Boost();
            player.RemoveItem();
            Destroy(gameObject);
        }  
    }
}
