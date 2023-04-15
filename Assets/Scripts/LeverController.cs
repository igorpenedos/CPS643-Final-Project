using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    public GameObject snapZone;

    public LeverInput RightLeverInput;
    public LeverInput LeftLeverInput;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnapZone"))
        {
            snapZone = other.gameObject;

            RightLeverInput.hapticOnController();
            LeftLeverInput.hapticOnController();
        }
    }
}
