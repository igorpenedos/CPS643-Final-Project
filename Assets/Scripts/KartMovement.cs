using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KartMovement : MonoBehaviour
{
    public Transform SteeringWheel;

    public Transform FrontRightWheelTransform;

    public Transform FrontLeftWheelTransform;

    public Transform RearRightWheelTransform;

    public Transform RearLeftWheelTransform;

    public WheelCollider FrontRightWheel;

    public WheelCollider FrontLeftWheel;

    public WheelCollider RearRightWheel;

    public WheelCollider RearLeftWheel;

    public LeverController LeverController;

    public TextMeshPro SpeedometerText;

    public AudioSource BoostSound;

    public EnvironmentSoundManager SoundManager;

    private float torque = 0.0f;

    public void Boost()
    {
        RearRightWheel.motorTorque = 1600;
        RearLeftWheel.motorTorque = 1600;

        Vector3 force = new Vector3(0, 0, 10000f);
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(force, ForceMode.Impulse);

        BoostSound.Play();
    }

    public bool IsKartMoving()
    {
        if (Mathf.Round(gameObject.GetComponent<Rigidbody>().velocity.magnitude) != 0)
        {
            return true;
        }
        else
        { 
            return false; 
        }
    }

    private void checkTorque()
    {
        if (LeverController.snapZone.name.Contains("1"))
        {
            torque = 800;
        }
        else if (LeverController.snapZone.name.Contains("2"))
        {
            torque = 400;
        }
        else if (LeverController.snapZone.name.Contains("3"))
        {
            torque = 200;
        }
        else if (LeverController.snapZone.name.Contains("4"))
        {
            torque = 0;
        }
        else if (LeverController.snapZone.name.Contains("5"))
        {
            torque = -400;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            return;
        }

        SoundManager.playCrash();
    }

    void FixedUpdate()
    {
        checkTorque();

        FrontRightWheel.steerAngle = (SteeringWheel.transform.localRotation.eulerAngles.y - 90) /4;
        FrontLeftWheel.steerAngle = (SteeringWheel.transform.localRotation.eulerAngles.y - 90) /4;
        
        RearRightWheel.motorTorque = torque;
        RearLeftWheel.motorTorque = torque;

        FrontRightWheelTransform.Rotate(0, FrontRightWheel.rpm / 60 * 360 * Time.deltaTime, 0, Space.Self);
        FrontLeftWheelTransform.Rotate(0, FrontLeftWheel.rpm / 60 * 360 * Time.deltaTime, 0, Space.Self);
        RearRightWheelTransform.Rotate(0, RearRightWheel.rpm / 60 * 360 * Time.deltaTime, 0, Space.Self);
        RearLeftWheelTransform.Rotate(0, RearLeftWheel.rpm / 60 * 360 * Time.deltaTime, 0, Space.Self);

        if (LeverController.snapZone.name.Contains("4"))
        {
            RearRightWheel.brakeTorque = 800;
            RearLeftWheel.brakeTorque = 800;
        } else
        {
            RearRightWheel.brakeTorque = 0;
            RearLeftWheel.brakeTorque = 0;
        }

        FrontRightWheelTransform.transform.localRotation = Quaternion.Euler(FrontRightWheelTransform.transform.localRotation.x, FrontRightWheel.steerAngle, 90);
        FrontLeftWheelTransform.transform.localRotation = Quaternion.Euler(FrontLeftWheelTransform.transform.localRotation.x, FrontLeftWheel.steerAngle, 90);

        SpeedometerText.text = Mathf.Round(gameObject.GetComponent<Rigidbody>().velocity.magnitude) + " m/s";
    }
}
