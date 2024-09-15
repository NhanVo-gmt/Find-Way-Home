using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] private float      speed;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position += (Vector3)(controller.horizontalInput * Vector2.right + controller.verticalInput * Vector2.up) * speed * Time.fixedDeltaTime;
    }
}
