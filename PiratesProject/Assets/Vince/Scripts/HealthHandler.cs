using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] BoatStatus boatStatus;

    private void Start()
    {
        healthSlider.value = boatStatus.boatHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        healthSlider.value = boatStatus.boatHealth;
    }
}
