using SimpleInputNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider RightWheel;

    public bool motorPower; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?

}
public class CarUserControl : MonoBehaviour
{

    public List<AxleInfo> axleInfos = new List<AxleInfo>();
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float brakeForce = 3000f;
    public GameObject SteerWheel;

    bool isBrakePedalPressed;
    float moveInput;

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {

        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0); //GetComponentInChildren<Transform>();

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        //float steering = maxSteeringAngle * SteerWheel.GetComponent<SteerWheel>().GetClampedValue();
        Gas();
        Brake();
        Steering();

    }

    //For Mobile Input;
    public void BrakeInputDown()
    {
        isBrakePedalPressed = true;
    }
    public void BrakeInputUp()
    {
        isBrakePedalPressed = false;
    }
    public void GasInput(float input)
    {
        moveInput = input;
    }

    void Gas()
    {
        //float motor = maxMotorTorque * Input.GetAxis("Vertical");  
        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.leftWheel.motorTorque = maxMotorTorque * moveInput;
            axleInfo.RightWheel.motorTorque = maxMotorTorque * moveInput;
        }

        //foreach (AxleInfo axleInfo in axleInfos)
        //{
        //    if (axleInfo.motorPower == true)
        //    {
        //        axleInfo.leftWheel.motorTorque = motor;
        //        axleInfo.RightWheel.motorTorque = motor;
        //    }


        //    ApplyLocalPositionToVisuals(axleInfo.leftWheel); //tekerin, wheel colliderin ile birlikte donmesini saglayan metot
        //    ApplyLocalPositionToVisuals(axleInfo.RightWheel); //bu metodu yazmasak sadece wheel collider saga sola dönerdi, teker donmezdi.
        //}
    }
    void Brake()
    {
        if (isBrakePedalPressed)
        {
            foreach (AxleInfo axleInfo in axleInfos)
            {
                axleInfo.leftWheel.brakeTorque = brakeForce;
                axleInfo.RightWheel.brakeTorque = brakeForce;
            }
        }
        else
        {
            foreach (AxleInfo axleInfo in axleInfos)
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.RightWheel.brakeTorque = 0;
            }
        }
    }
    void Steering()
    {
        float steering = maxSteeringAngle * SteerWheel.GetComponent<SteerWheel>().GetClampedValue();
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //if (axleInfo.motorPower == true)
            //{
            //    axleInfo.leftWheel.motorTorque = motor;
            //    axleInfo.RightWheel.motorTorque = motor;
            //}
            if (axleInfo.steering == true)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel); //tekerin, wheel colliderin ile birlikte donmesini saglayan metot
            ApplyLocalPositionToVisuals(axleInfo.RightWheel); //bu metodu yazmasak sadece wheel collider saga sola dönerdi, teker donmezdi.
        }
    }
}
