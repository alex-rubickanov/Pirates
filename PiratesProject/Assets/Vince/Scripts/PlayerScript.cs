using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            transform.position += Vector3.up * 2f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            transform.position += -Vector3.up * 2f * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.L))
        {
            transform.position += Vector3.right * 2f * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.J))
        {
            transform.position += -Vector3.right * 2f * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position;
        }
    }
}
