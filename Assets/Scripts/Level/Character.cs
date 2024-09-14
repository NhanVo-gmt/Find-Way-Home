using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Controller controller;

    private void Update()
    {
        transform.position += (Vector3)(controller.horizontalInput * Vector2.right + controller.verticalInput * Vector2.up);
    }
}
