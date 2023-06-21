using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Movement movement;
    InputHandler inputHandler;

    [SerializeField] BoatMovement boatMovement;
    [SerializeField] CannonScript canonScript;
    [SerializeField] bool doingSomething;
    [SerializeField] KeyCode interactKey;
    private void Start()
    {
        movement = GetComponent<Movement>();
        inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        CheckControls();
        BoatInteraction();
        CanonInteraction();
    }
    private void CheckControls()
    {
        if (inputHandler.GetPlayerRole() == "P1_")
        {
            interactKey = KeyCode.LeftControl;
        }
        else if (inputHandler.GetPlayerRole() == "P1_")
        {
            interactKey = KeyCode.RightControl;
        }
        else
        {
            interactKey = KeyCode.Joystick1Button0;
        }
    }

    private void BoatInteraction()
    {
        if(boatMovement != null)
        {
            if (Input.GetKeyDown(interactKey) && !doingSomething)
            {
                doingSomething = true;
                boatMovement.enabled = true;
                movement.enabled = false;
                movement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                movement.GetComponent<Rigidbody2D>().simulated = false;
            }
            else if (Input.GetKeyDown(interactKey) && doingSomething)
            {
                movement.GetComponent<Rigidbody2D>().simulated = true;
                doingSomething = false;
                boatMovement.enabled = false;
                movement.enabled = true;
                boatMovement = null;

            }
        }
    }

    private void CanonInteraction()
    {
        if(canonScript != null)
        {
            if (Input.GetKeyDown(interactKey) && !doingSomething)
            {
                doingSomething = true;
                canonScript.enabled = true;
                movement.enabled = false;
                movement.GetComponent<Rigidbody2D>().simulated = false;
            }
            else if (Input.GetKeyDown(interactKey) && doingSomething)
            {
                movement.GetComponent<Rigidbody2D>().simulated = true;
                doingSomething = false;
                canonScript.enabled = false;
                movement.enabled = true;
                canonScript = null;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
            boatMovement = collision.gameObject.GetComponentInParent<BoatMovement>();
            boatMovement.playerRole = inputHandler.GetPlayerRole();
        }

        if(collision.tag == "Canon")
        {
            canonScript = collision.gameObject.GetComponent<CannonScript>();
            canonScript.CheckControls(inputHandler.GetPlayerRole());
            canonScript.playerRole = inputHandler.GetPlayerRole();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
           // boatMovement = null;
        }

        if (collision.tag == "Canon")
        {
           // canonScript = null;
        }
    }
}
