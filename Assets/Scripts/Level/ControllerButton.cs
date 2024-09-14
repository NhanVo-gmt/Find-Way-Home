using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButton : MonoBehaviour
{
    public enum ButtonDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public ButtonDirection          direction;
    public Action<ControllerButton> OnClickButton;
    public Action<ControllerButton> OnExitButton;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
        {
            OnClick();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
        {
            OnExit();
        }
    }

    public void OnClick()
    {
        OnClickButton?.Invoke(this);
    }

    public void OnExit()
    {
        OnExitButton?.Invoke(this);
    }
}
