using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    public GameObject snapZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnapZone"))
        {
            snapZone = other.gameObject;
        }
    }
}
