using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetInput : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Behaviour_Pose ControllerPose;

    public SteamVR_Action_Boolean JoyStickPress;

    public PlayerController Player;

    // Update is called once per frame
    void Update()
    {
        if (JoyStickPress.GetStateDown(handType))
        {
            Player.Reset();
        }
    }
}
