using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnCancelAction;
    public event EventHandler OnInteractAlternate;

    private static GameInput gameInput = null;

    private PlayerInputActions inputActions;

    private GameInput() { 
    }

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        gameInput = this; //Unity by default creates an instance of this object when its loaded
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += Interact_performed;
        inputActions.Player.Interact.canceled += Interact_canceled;
        inputActions.Player.InteractAlternate.performed += InteractAlternate_performed;

    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke( this, EventArgs.Empty );
    }

    private void Interact_canceled(InputAction.CallbackContext obj)
    {
        OnCancelAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(InputAction.CallbackContext obj)
    {
        OnInteractAlternate?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }

    public static GameInput GetInstance() {

        return gameInput;

    }
}
