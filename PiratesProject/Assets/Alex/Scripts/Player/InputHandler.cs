using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Select Role")]
    [SerializeField] PlayerRole playerNum;
    private string playerRole;

    public enum PlayerRole
    {
        WASD,
        ARROWS,
        JOYSTICK
    }

    private void Awake()
    {
        CheckPlayerRole();
    }
    private void CheckPlayerRole()
    {
        switch (playerNum) {
            case PlayerRole.WASD:
                playerRole = "P1_";
                break;
            case PlayerRole.ARROWS:
                playerRole = "P2_";
                break;
            case PlayerRole.JOYSTICK:
                playerRole = "P3_";
                break;
        }
    }

    public string GetPlayerRole()
    {
        return playerRole;
    }
}
