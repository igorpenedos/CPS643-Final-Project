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

    public LeverController LeverController;

    private float torque = 0.0f;

    private bool isBoosting = false;
    private float boostingTimer = 0f;

    public void Boost()
    {
        isBoosting = true;
    }

    private void checkTorque()
    {
        if (LeverController.snapZone.name.Contains("1"))
        {
            torque = 400;
        }
        else if (LeverController.snapZone.name.Contains("2"))
        {
            torque = 200;
        }
        else if (LeverController.snapZone.name.Contains("3"))
        {
            torque = 100;
        }
        else if (LeverController.snapZone.name.Contains("4"))
        {
            torque = 0;
        }
        else if (LeverController.snapZone.name.Contains("5"))
        {
            torque = -200;
        }
    }

    void FixedUpdate()
    {
        if (isBoosting && boostingTimer <= 3f)
        {
            RearRightWheel.motorTorque = 800;
            RearLeftWheel.motorTorque = 800;
            boostingTimer += Time.deltaTime;
            return;
        }
        else
        {
            boostingTimer  = 0f;
            isBoosting = false;
        }


        checkTorque();

        FrontRightWheel.steerAngle = SteeringWheel.transform.localRotation.eulerAngles.y - 90;
        FrontLeftWheel.steerAngle = SteeringWheel.transform.localRotation.eulerAngles.y - 90;
        
        RearRightWheel.motorTorque = torque;
        RearLeftWheel.motorTorque = torque;

        if (torque == 0)
        {
            RearRightWheel.brakeTorque = 400;
            RearLeftWheel.brakeTorque = 400;
        } else
        {
            RearRightWheel.brakeTorque = 0;
            RearLeftWheel.brakeTorque = 0;
        }

        FrontRightWheelTransform.transform.localRotation = Quaternion.Euler(FrontRightWheelTransform.transform.localRotation.x, FrontRightWheel.steerAngle, 90);
        FrontLeftWheelTransform.transform.localRotation = Quaternion.Euler(FrontLeftWheelTransform.transform.localRotation.x, FrontLeftWheel.steerAngle, 90);
    }
}
