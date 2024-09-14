using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private List<ControllerButton> controllerButtons;

    public float horizontalInput { get; private set; } = 0;
    public float verticalInput   { get; private set; } = 0;
    
    private void Awake()
    {
        foreach (var controllerButton in controllerButtons)
        {
            controllerButton.OnClickButton += Move;
            controllerButton.OnExitButton += Stop;
        }
    }
    
    private void Move(ControllerButton button)
    {
        switch (button.direction)
        {
            case ControllerButton.ButtonDirection.Up:
                verticalInput = 1f;
                break;
            case ControllerButton.ButtonDirection.Down:
                verticalInput = -1f;
                break;
            case ControllerButton.ButtonDirection.Left:
                horizontalInput = -1f;
                break;
            case ControllerButton.ButtonDirection.Right:
                horizontalInput = 1f;
                break;
        }
    }
    
    private void Stop(ControllerButton button)
    {
        switch (button.direction)
        {
            case ControllerButton.ButtonDirection.Up:
                verticalInput = 0f;
                break;
            case ControllerButton.ButtonDirection.Down:
                verticalInput = 0f;
                break;
            case ControllerButton.ButtonDirection.Left:
                horizontalInput = 0f;
                break;
            case ControllerButton.ButtonDirection.Right:
                horizontalInput = 0f;
                break;
        }
    }
}
