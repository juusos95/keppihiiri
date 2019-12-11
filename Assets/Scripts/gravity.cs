using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;
    public static float globalGravity = -9.81f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * rb.mass * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
