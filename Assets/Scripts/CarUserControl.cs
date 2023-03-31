using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider RightWheel;

    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?

}
public class CarUserControl : MonoBehaviour
{

    public List<AxleInfo> axleInfos = new List<AxleInfo>();
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float brakeForce = 3000f;
    public GameObject SteerWheel;
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
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float steering = maxSteeringAngle * SteerWheel.GetComponent<SteerWheel>().GetClampedValue();

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor == true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    axleInfo.leftWheel.brakeTorque = brakeForce;
                    axleInfo.RightWheel.brakeTorque = brakeForce;
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    axleInfo.leftWheel.brakeTorque = 0;
                    axleInfo.RightWheel.brakeTorque = 0;
                }
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.RightWheel.motorTorque = motor;
            }
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
