using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoGearsRatioCalculator : MonoBehaviour
{
    [SerializeField]
    private float touchDistanceThresholdMeters = .01f;
    [SerializeField]
    private Gear[] gears;

    void Start()
    {

    }

    void Update()
    {
        if (AreGearsTouching(gears[0], gears[1]))
        {
            gears[0].RevolutionsPerSecond = 1f;
            gears[1].RevolutionsPerSecond = 1f;
        }
        else
        {
            gears[0].RevolutionsPerSecond = 0f;
            gears[1].RevolutionsPerSecond = 0f;
        }
    }

    private bool AreGearsTouching(Gear gearA, Gear gearB)
    {
        float distance = Vector3.Distance(gearA.transform.position, gearB.transform.position);
        distance -= gearA.Radius;
        distance -= gearB.Radius;
        bool areTouching = distance < touchDistanceThresholdMeters;
        return areTouching;
    }
}
