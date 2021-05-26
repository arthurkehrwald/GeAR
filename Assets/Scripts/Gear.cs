using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField]
    private const float radius = .05f;
    public float Radius
    {
        get => radius;
    }
    public float RevolutionsPerSecond { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        if (RevolutionsPerSecond > 0f)
        {
            transform.Rotate(Vector3.up * 360.0f * RevolutionsPerSecond * Time.deltaTime);
        }    
    }
}
