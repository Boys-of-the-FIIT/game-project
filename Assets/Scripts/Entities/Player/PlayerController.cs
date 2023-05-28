using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;

    private float currentSpeed;
    private PlayerInput playerInput;
    private InputAction movement;
    private Vector2 moveVector = Vector2.zero;

    public float CurrentSpeed => currentSpeed;
    
    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    
    private void FixedUpdate()
    {
        var newPos = Time.deltaTime * currentSpeed * moveVector;
        transform.position = transform.position + new Vector3(newPos.x, newPos.y, 0);
    }  

    private void Start()
    {
        currentSpeed = walkSpeed;
    }

    private void OnMoveCancel(InputAction.CallbackContext obj)
    {
        moveVector = Vector2.zero;
    }
    
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        moveVector = movement.ReadValue<Vector2>();
    }
    
    private void OnEnable()
    {
        movement = playerInput.Player.Movement;
        movement.Enable();
        SubscribeAll();
    }
    
    private void OnDisable()
    {
        movement.Disable();
        UnsubscribeAll();
    }

    private void SubscribeAll()
    {
        movement.performed += OnMovePerformed;
        movement.canceled += OnMoveCancel;
    }

    private void UnsubscribeAll()
    {
        movement.performed -= OnMovePerformed;
        movement.canceled -= OnMoveCancel;
    }
}