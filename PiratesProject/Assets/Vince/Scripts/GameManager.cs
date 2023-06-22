using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject resultUI;
    [SerializeField] GameObject winUI;
    [SerializeField] BoatStatus boatStatus;
    [SerializeField] TimerManager timerManager;

    // Update is called once per frame
    void Update()
    {
        CheckIfLost();
        CheckIfWin();
    }

    private void CheckIfWin()
    {
        if (timerManager.GetTime <= 0)
        {
            resultUI.SetActive(true);
            winUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void CheckIfLost()
    {
        if (boatStatus.boatHealth <= 0)
        {
            resultUI.SetActive(true);
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
