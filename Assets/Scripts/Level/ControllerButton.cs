using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButton : MonoBehaviour
{
    public Action OnClickButton;
    public Action OnExitButton;

    public Sprite normal;
    public Sprite pressed;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        spriteRenderer.sprite = pressed;
        OnClickButton?.Invoke();
    }

    public void OnExit()
    {
        spriteRenderer.sprite = normal;
        OnExitButton?.Invoke();
    }
}
