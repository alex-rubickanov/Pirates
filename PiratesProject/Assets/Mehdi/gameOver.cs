using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public int boatHp = 20;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(boatHP == 0)
        {
            SceneManager.LoadScene(3);

        }
    }
}
