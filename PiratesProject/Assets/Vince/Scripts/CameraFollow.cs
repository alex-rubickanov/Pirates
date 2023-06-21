using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform boatPos;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        FollowBoat();
    }

    private void FollowBoat()
    {
        Vector3 desiredPos = boatPos.position + offset;
        Vector3 SmoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed);
        transform.position = SmoothedPos;
    }
}
