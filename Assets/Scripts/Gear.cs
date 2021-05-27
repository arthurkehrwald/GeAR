using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gear : MonoBehaviour
{
    [SerializeField]
    private float driveTorque = 0.0f;
    public float DriveTorque
    {
        get => driveTorque;
        private set => driveTorque = value;
    }
    private Rigidbody rb = null;

    private static Gear referenceGear = null;
    private float[] prevSpeeds = new float[10];
    private int speedIndex = 0;
    public float AvgSpeed { get; private set; }
    public float RelativeSpeed { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < prevSpeeds.Length; i++)
        {
            prevSpeeds[i] = 0.0f;
        }
        
        // Assumes there is only one drive gear in the scene
        // Otherwise, a random one of the drive gears will become the reference.        
        if (DriveTorque != 0.0f)
        {
            referenceGear = this;
        }
        StartCoroutine(CalcAvgSpeed());
    }

    private void FixedUpdate()
    {
        rb.AddTorque(Vector3.up * DriveTorque * Time.fixedDeltaTime);
    }

    private IEnumerator CalcAvgSpeed()
    {
        yield return new WaitForEndOfFrame();
        while (true)
        {
            prevSpeeds[speedIndex] = rb.angularVelocity.y / Mathf.PI / 2;
            speedIndex++;
            if (speedIndex == prevSpeeds.Length)
            {
                speedIndex = 0;
            }
            AvgSpeed = 0.0f;            
            for (int i = 0; i < prevSpeeds.Length; i++)
            {
                AvgSpeed += prevSpeeds[i];
            }
            AvgSpeed /= prevSpeeds.Length; 
            AvgSpeed = Mathf.Abs(AvgSpeed);
            if (Gear.referenceGear)
            {
                RelativeSpeed = AvgSpeed / Gear.referenceGear.AvgSpeed;
            }
            else
            {
                RelativeSpeed = AvgSpeed;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
