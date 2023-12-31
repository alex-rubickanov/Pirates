using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Movement movement;
    InputHandler inputHandler;

    [SerializeField] BoatMovement2 boatMovement;
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
        MovementEnabler();

    }
    private void CheckControls()
    {
        if (inputHandler.GetPlayerRole() == "P1_")
        {
            interactKey = KeyCode.LeftControl;
        }
        else if (inputHandler.GetPlayerRole() == "P2_")
        {
            interactKey = KeyCode.RightControl;
        }
        else if((inputHandler.GetPlayerRole() == "P3_"))
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
                movement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            else if (Input.GetKeyDown(interactKey) && doingSomething)
            {
                doingSomething = false;
                boatMovement.enabled = false;
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
            }
            else if (Input.GetKeyDown(interactKey) && doingSomething)
            {
                doingSomething = false;
                canonScript.enabled = false;
                canonScript = null;

            }
        }
    }

    private void MovementEnabler()
    {
        if(doingSomething) {
            movement.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            movement.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            movement.enabled = false;
        } else {
            movement.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            movement.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
            boatMovement = collision.gameObject.GetComponentInParent<BoatMovement2>();

            if (!boatMovement.enableDriving)
            {
                boatMovement.playerRole = inputHandler.GetPlayerRole();
            }
        }

        if(collision.tag == "Canon")
        {
            canonScript = collision.gameObject.GetComponent<CannonScript>();

            if (!canonScript.enableCannon)
            {
                canonScript.CheckControls(inputHandler.GetPlayerRole());
                canonScript.playerRole = inputHandler.GetPlayerRole();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
           boatMovement = null;
        }

        if (collision.tag == "Canon")
        {
           canonScript = null;
        }
    }
}
