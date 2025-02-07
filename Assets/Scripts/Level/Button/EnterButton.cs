using System;
using System.Collections.Generic;
using UnityEngine;

public class EnterButton : ButtonBehaviour
{
    [Header("Enter Button")]
    [SerializeField] private List<GameObject> dropItems = new();

    private bool isActivated = false;

    private void Start()
    {
        foreach (GameObject dropItem in dropItems)
        {
            dropItem.gameObject.SetActive(false);
        }
    }

    protected override void OnPlayerPressed()
    {
        base.OnPlayerPressed();

        if (isActivated) return;

        isActivated = true;
        foreach (GameObject dropItem in dropItems)
        {
            dropItem.gameObject.SetActive(true);
        }
    }

}