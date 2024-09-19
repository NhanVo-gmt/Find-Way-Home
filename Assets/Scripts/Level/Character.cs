using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterState currentState;
    [SerializeField] private Controller controller;
    [SerializeField] private float      speed;

    private CharacterVisual visual; 
    
    public Action<CharacterState> OnChangeState;
    

    private void Awake()
    {
        visual = GetComponentInChildren<CharacterVisual>();
        
    }

    private void Update()
    {
        if (controller.horizontalInput != 0 || controller.verticalInput != 0)
        {
            ChangeState(CharacterState.Move);
        }
        else ChangeState(CharacterState.Idle);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position += (Vector3)(controller.horizontalInput * Vector2.right + controller.verticalInput * Vector2.up) * speed * Time.fixedDeltaTime;
        visual.ChangeDirection(controller.horizontalInput);
    }

    void ChangeState(CharacterState newState)
    {
        if (currentState == newState) return;
        
        currentState = newState;
        visual.UpdateAnim(currentState);
    }
}

public enum CharacterState
{
    Idle,
    Move
}
