using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : ASubject
{

    private static GameInput gameInput = null;

    private PlayerInputActions inputActions;

    private GameInput() { 
    }

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        gameInput = this; //Unity by default creates an instance of this object when its loaded
        inputActions.Player.Enable();

    }

    private void Start()
    {

    }

    public bool IsInteractionPerformed() { 
        return inputActions.Player.Interact.IsPressed();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }

    public PlayerInputActions getInputAction() { 
        return inputActions;
    }

    public static GameInput getInstance() {

        return gameInput;

    }

    public override void addObserver(AObserver observer)
    {
        this.observers.Add(observer);
    }

    public override void removeObserver(AObserver observer)
    {
        this.observers.Remove(observer);
    }

    public override void notifyObservers()
    {
        foreach ( AObserver observer in this.observers ) {
            observer.update();
        }
    }
}
