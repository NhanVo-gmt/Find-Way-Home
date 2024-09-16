using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButton : MonoBehaviour
{
    public Action OnClickButton;
    public Action OnExitButton;
    
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
        OnClickButton?.Invoke();
    }

    public void OnExit()
    {
        OnExitButton?.Invoke();
    }
}
