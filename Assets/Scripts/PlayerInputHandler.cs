using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerInput playerInput;
    private ScooterDrive scooterDriveScript;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        int index = playerInput.playerIndex;
        var allScooterDriveScrpits = FindObjectsOfType<ScooterDrive>();
        scooterDriveScript = allScooterDriveScrpits.FirstOrDefault(x => x.playerIndex == index);
        //if (GetComponent<ScooterDrive>().playerIndex == index)
        //{
        //    scooterDriveScript = GetComponent<ScooterDrive>();
        //}
    }

    public void OnBrake(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.isBraking = true;
        }
        else if (context.canceled)
        {
            scooterDriveScript.isBraking = false;
            scooterDriveScript.isBrakingCompleted = true;
        }
    }
    public void OnTurnRight(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.turnRight = true;
        }
        else if (context.canceled)
        {
            scooterDriveScript.turnRight = false;
        }
    }
    public void OnTurnLeft(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.turnLeft = true;
        }
        else if (context.canceled)
        {
            scooterDriveScript.turnLeft = false;
        }
    }
    public void OnAccelerate(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.isAccelerating = true;
        }
        else if (context.canceled)
        {
            scooterDriveScript.isAccelerating = false;
            scooterDriveScript.acceleratingCompleted = true;
        }
    }
    public void OnPhoneOutIn(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.PhoneOutIn();
        }
    }
    public void OnNavigateUIUp(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.HandleNavigateUIUp();
        }
    }
    public void OnNavigateUIRight(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.HandleNavigateUIRight();
        }
    }
    public void OnNavigateUIDown(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.HandleNavigateUIDown();
        }
    }
    public void OnNavigateUILeft(CallbackContext context)
    {
        if (context.performed)
        {
            scooterDriveScript.HandleNavigateUILeft();
        }
    }
}
