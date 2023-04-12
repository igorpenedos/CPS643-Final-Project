using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    public PlayerController player;
    public KartMovement kart;
    public Transform PickUpSpawnPlatform;

    private bool exitedVehicle = false;
    private float timeToDestroy = 0f;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Kart"))
        {
            exitedVehicle = true;
        }
    }

    void FixedUpdate()
    {
        if (exitedVehicle)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;

            if (timeToDestroy >= 5.0f)
            {
                Destroy(gameObject);
            }
            else
            {
                timeToDestroy += Time.deltaTime;
            }
        }
    }
}
