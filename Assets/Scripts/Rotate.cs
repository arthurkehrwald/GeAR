using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RevolutionsPerSecond { get; set; }
    void Start()
    {
        RevolutionsPerSecond = 0f;
    }

    void Update()
    {
        if (RevolutionsPerSecond > 0f)
        {
            transform.Rotate(Vector3.up * RevolutionsPerSecond * 360.0f * Time.deltaTime, Space.Self);
        }
    }
}
