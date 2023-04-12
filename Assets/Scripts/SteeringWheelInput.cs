using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteeringWheelInput : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Behaviour_Pose ControllerPose;

    public SteamVR_Action_Boolean TriggerClick;

    public Transform SteeringWheel;

    public Transform FrontRightWheel;
    public Transform FrontLeftWheel;

    public MushroomInput MushroomInput;
    public ShellInput ShellInput;

    private bool isInSteeringWheel = false;

    void OnTriggerStay(Collider other)
    {
        if (TriggerClick.GetState(handType) && other.gameObject.CompareTag("SteeringWheel"))
        {
            isInSteeringWheel = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isInSteeringWheel)
        {
            isInSteeringWheel = false;
        }    
    }

    private void FixedUpdate()
    {
        if (TriggerClick.GetState(handType) && isInSteeringWheel && !MushroomInput.hasMushroom() && !ShellInput.hasShell())
        {
            Vector3 relative = SteeringWheel.transform.InverseTransformPoint(ControllerPose.transform.position);

            float angle = Mathf.Atan2(relative.z, relative.y) * Mathf.Rad2Deg;

            float futureAngle = (SteeringWheel.transform.localRotation.eulerAngles.y) + angle;

            if (futureAngle > 45 & futureAngle < 135)
            {
                SteeringWheel.transform.Rotate(0f, angle, 0f);
            }
        }
    }
}
