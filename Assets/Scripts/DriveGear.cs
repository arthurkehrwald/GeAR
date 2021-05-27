using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveGear : MonoBehaviour
{
    [SerializeField]
    private float torque = 0.5f;
    private Rigidbody rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(Vector3.up * torque * Time.fixedDeltaTime);
    }
}
