using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMovement : MonoBehaviour
{
    public Transform SteeringWheel;

    public Transform FrontRightWheelTransform;

    public Transform FrontLeftWheelTransform;

    public WheelCollider FrontRightWheel;

    public WheelCollider FrontLeftWheel;

    public WheelCollider RearRightWheel;

    public WheelCollider RearLeftWheel;

    // Update is called once per frame
    void FixedUpdate()
    {
        FrontRightWheel.steerAngle = SteeringWheel.transform.localRotation.eulerAngles.y - 90;
        FrontLeftWheel.steerAngle = SteeringWheel.transform.localRotation.eulerAngles.y - 90;

        RearRightWheel.motorTorque = 100;
        RearLeftWheel.motorTorque = 100;

        FrontRightWheelTransform.transform.localRotation = Quaternion.Euler(FrontRightWheelTransform.transform.localRotation.x, FrontRightWheel.steerAngle, 90);
        FrontLeftWheelTransform.transform.localRotation = Quaternion.Euler(FrontLeftWheelTransform.transform.localRotation.x, FrontLeftWheel.steerAngle, 90);
    }
}
