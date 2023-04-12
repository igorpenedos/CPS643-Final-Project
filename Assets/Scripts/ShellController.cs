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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Kart"))
        {
            exitedVehicle = true;
            gameObject.transform.localScale = new Vector3(2,2,2);
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
