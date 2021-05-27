using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentityRotation : MonoBehaviour
{
    private void Update()
    {
        //Vector3 targetPos = Camera.main.transform.position;
        /*
        targetPos = transform.InverseTransformPoint(targetPos);
        targetPos.y = 0f;
        targetPos = transform.TransformPoint(targetPos);
        */
        transform.rotation = Quaternion.identity;
        //transform.Rotate(Vector3.left * 90.0f, Space.Self);
        //transform.Rotate(Vector3.back * 90.0f, Space.Self);
    }
}
