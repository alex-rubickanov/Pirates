using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonArrowAnim : MonoBehaviour
{
    public float amplitude = 1f;
    public float speed = 1f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
