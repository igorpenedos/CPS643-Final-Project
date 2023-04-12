using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MushroomInput : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Behaviour_Pose ControllerPose;

    public SteamVR_Action_Boolean TriggerClick;

    private Transform Mushroom;

    private MushroomController MushroomInfo;

    public bool hasMushroom()
    {
        if (Mushroom != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (TriggerClick.GetState(handType) && other.gameObject.CompareTag("Mushroom"))
        {
            Mushroom = other.gameObject.transform;
            MushroomInfo = Mushroom.GetComponent<MushroomController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mushroom") && Mushroom != null)
        {
            Mushroom = null;
            MushroomInfo = null;
        }
    }

    void Update()
    {
        if (Mushroom == null) 
        {
            return;
        }

        if (TriggerClick.GetState(handType) & Mushroom)
        {
            Mushroom.parent = ControllerPose.transform;
        }
        else if (TriggerClick.GetStateUp(handType))
        {
            Mushroom.position = MushroomInfo.PickUpSpawnPlatform.position + new Vector3(0, 0.1f, 0);
            Mushroom.rotation = Quaternion.identity;
            Mushroom.parent = MushroomInfo.PickUpSpawnPlatform;
            Mushroom = null;
            MushroomInfo = null;
        }
    }
}
