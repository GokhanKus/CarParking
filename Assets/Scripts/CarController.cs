using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //[SerializeField] WheelCollider frontRightWheel;
    //[SerializeField] WheelCollider frontLeftWheel;
    //[SerializeField] WheelCollider RearRightWheel;
    //[SerializeField] WheelCollider RearLeftWheel;

    ////[SerializeField] Transform frontRightWheelTransform;
    ////[SerializeField] Transform frontLeftWheelTransform;
    ////[SerializeField] Transform RearRightWheelTransform;
    ////[SerializeField] Transform RearLeftWheelTransform;

    //public float motorPower = 500f;
    //public float breakingForce = 300f;
    //public float maxTurnAngle = 30f;

    //private float currentAcceleration = 0;
    //private float currentBreakForce = 0;
    //private float currentTurnAngle = 0;


    void FixedUpdate()
    {
        //currentAcceleration = motorPower * Input.GetAxis("Vertical");
        //currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        ////apply acceleration to front wheels
        //RearRightWheel.motorTorque = currentAcceleration;
        //RearLeftWheel.motorTorque = currentAcceleration;

        ////currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        //frontRightWheel.steerAngle = currentTurnAngle;
        //frontLeftWheel.steerAngle = currentTurnAngle;

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    RearRightWheel.brakeTorque = breakingForce;
        //    RearLeftWheel.brakeTorque = breakingForce;
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    RearRightWheel.brakeTorque = 0;
        //    RearLeftWheel.brakeTorque = 0;
        //}

        

        //apply breaking force to all wheels
        //frontRightWheel.brakeTorque = currentBreakForce;
        //frontLeftWheel.brakeTorque = currentBreakForce;
        //RearRightWheel.brakeTorque = currentBreakForce;
        //RearLeftWheel.brakeTorque = currentBreakForce;

        

        //RotateWheels(frontRightWheel, frontRightWheelTransform);
        //RotateWheels(frontLeftWheel, frontLeftWheelTransform);
        //RotateWheels(RearRightWheel, RearRightWheelTransform);
        //RotateWheels(RearLeftWheel, RearLeftWheelTransform);

    }
    //void RotateWheels(WheelCollider col, Transform transform)
    //{
    //    //get wheel coll state
    //    Vector3 position;
    //    Quaternion rotation;
    //    col.GetWorldPose(out position, out rotation);

    //    //set wheel transform state 
    //    transform.position = position;
    //    transform.rotation = rotation;

    //}
}
