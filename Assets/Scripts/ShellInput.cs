using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShellInput : MonoBehaviour
{

    public SteamVR_Input_Sources handType;

    public SteamVR_Behaviour_Pose ControllerPose;

    public SteamVR_Action_Boolean TriggerClick;

    public SteamVR_Action_Boolean PrimaryButtonClick;

    public PlayerController Player;

    private Transform Shell;

    private ShellController ShellInfo;

    public bool hasShell()
    {
        if (Shell != null)
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
        if (TriggerClick.GetState(handType) && other.gameObject.CompareTag("Shell"))
        {
            Shell = other.gameObject.transform;
            ShellInfo = Shell.GetComponent<ShellController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Shell)
        {
            Shell = null;
            Shell = null;
        }
    }

    void Update()
    {
        if (Shell == null)
        {
            return;
        }

        if (TriggerClick.GetState(handType) & Shell)
        {
            Shell.parent = ControllerPose.transform;

            if (PrimaryButtonClick.GetState(handType))
            {
                Shell.parent = null;
                Shell.GetComponent<Rigidbody>().isKinematic = false;
                Shell.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 1000f);

                Shell = null;
                Player.RemoveItem();
            }
        }
        else if (TriggerClick.GetStateUp(handType))
        {
            Shell.position = ShellInfo.PickUpSpawnPlatform.position + new Vector3(0, 0.1f, 0);
            Shell.rotation = Quaternion.identity;
            Shell.parent = ShellInfo.PickUpSpawnPlatform;
        }
    }
}
