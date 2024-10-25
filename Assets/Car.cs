using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float accleration;
    public float maxSteeringAngle;
    public Wheel[] frontWheels;
    public Wheel[] backWheels;

    [Range(-1, 1)]
    public float forward;

    [Range(-1,1)]
    public float turn;

    public float speedKmh;
    new Rigidbody rigidbody;
    
    void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate(){
        speedKmh = rigidbody.linearVelocity.magnitude ;
    }
    void FixedUpdate()
    {
        foreach (var wheel in frontWheels){
            wheel.collider.motorTorque = forward * accleration * 5000000.0f;
            wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, turn * maxSteeringAngle , 1f);
        }
    }
}