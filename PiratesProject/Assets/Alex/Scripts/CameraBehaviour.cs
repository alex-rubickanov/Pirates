using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject playerBoat;
    private void Update()
    {
        transform.position = new Vector3(0, playerBoat.transform.position.y, -10);
    }
}
