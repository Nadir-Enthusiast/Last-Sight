using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCasting : MonoBehaviour
{
    public static float distanceFromTarget;
    public float toTarget;

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            distanceFromTarget = Hit.distance;
            toTarget = distanceFromTarget;
        }
        
    }
}
