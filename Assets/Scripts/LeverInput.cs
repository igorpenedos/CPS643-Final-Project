using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeverInput : MonoBehaviour
{

    public SteamVR_Input_Sources handType;

    public SteamVR_Behaviour_Pose ControllerPose;

    public SteamVR_Action_Boolean TriggerClick;

    public Transform Slider;

    public Transform StickKnob;

    public LeverController LeverControllerVars;

    private bool isInStickKnob;

    public bool currentlyOnLever()
    {
        return isInStickKnob;
    }

    void OnTriggerStay(Collider other)
    {
        if (TriggerClick.GetState(handType) && other.gameObject.CompareTag("StickKnob"))
        {
            isInStickKnob = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isInStickKnob)
        {
            isInStickKnob = false;
        }
    }

    void FixedUpdate()
    {
        if (TriggerClick.GetState(handType) & isInStickKnob)
        {
            Vector3 relative = Slider.transform.InverseTransformPoint(ControllerPose.transform.position);

            if (relative.x < 0.4 && relative.x > -0.4)
            {
                StickKnob.localPosition = new Vector3(relative.x, StickKnob.localPosition.y, StickKnob.localPosition.z);
            }
        }
        else if (TriggerClick.GetStateUp(handType))
        {
            StickKnob.transform.localPosition = new Vector3(LeverControllerVars.snapZone.GetComponent<Transform>().localPosition.x, StickKnob.transform.localPosition.y, StickKnob.transform.localPosition.z);
        }
    }
}
