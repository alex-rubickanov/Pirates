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
        Player1,
        Player2,
        Player3
    }

    private void Awake()
    {
        CheckPlayerRole();
    }
    private void CheckPlayerRole()
    {
        switch (playerNum) {
            case PlayerRole.Player1:
                playerRole = "P1_";
                break;
            case PlayerRole.Player2:
                playerRole = "P2_";
                break;
            case PlayerRole.Player3:
                playerRole = "P3_";
                break;
        }
    }

    public string GetPlayerRole()
    {
        return playerRole;
    }
}
