using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction movement;
    private Vector2 moveVector = Vector2.zero;
    private PlayerEntity player;
    
    [Inject]
    private void Construct(PlayerEntity player)
    {
        this.player = player;
    }

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    
    private void FixedUpdate()
    {
        var newPos = Time.deltaTime * player.Stats.Speed * moveVector;
        transform.position = transform.position + new Vector3(newPos.x, newPos.y, 0);
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