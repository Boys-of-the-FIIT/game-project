using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    
    private float currentSpeed;
    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction run;
    private Vector2 moveVector = Vector2.zero;

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

    private void OnEnable()
    {
        movement = playerInput.Player.Movement;
        run = playerInput.Player.Run;
        movement.Enable();
        run.Enable();
        SubscribeAll();
    }

    private void OnRunPerformed(InputAction.CallbackContext obj)
    {
        // set run animation
        currentSpeed = runSpeed;
    }

    private void OnRunCancelled(InputAction.CallbackContext obj)
    {
        // disable run animation
        currentSpeed = walkSpeed;
    }
    
    private void OnMoveCancel(InputAction.CallbackContext obj)
    {
        // disable walk animation
        moveVector = Vector2.zero;
    }
    
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        // set walk animation
        moveVector = movement.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        movement.Disable();
        run.Disable();
        UnsubscribeAll();
    }

    private void SubscribeAll()
    {
        movement.performed += OnMovePerformed;
        movement.canceled += OnMoveCancel;
        run.performed += OnRunPerformed;
        run.canceled += OnRunCancelled;
    }

    private void UnsubscribeAll()
    {
        movement.performed -= OnMovePerformed;
        movement.canceled -= OnMoveCancel;
        run.performed -= OnRunPerformed;
        run.canceled -= OnRunCancelled;
    }
}