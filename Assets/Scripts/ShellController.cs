using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    private bool exitedVehicle = false;

    public PlayerController player;
    public KartMovement kart;
    public Transform PickUpSpawnPlatform;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Kart"))
        {
            exitedVehicle = true;
        }
    }

    void Update()
    {
        if (exitedVehicle)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}
