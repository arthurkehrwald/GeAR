using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private Rigidbody rigidbody = null;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbody.AddTorque(Vector3.up * Time.fixedDeltaTime * .5f);
    }
}
