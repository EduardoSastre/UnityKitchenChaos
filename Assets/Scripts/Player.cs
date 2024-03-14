using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask clearCounterLayerMask;

    private bool isWalking;
    private const float PLAYER_RADIUS = 0.7f;
    private const float PLAYER_WEIGHT = PLAYER_RADIUS*3;
    private const float PLAYER_HEIGHT = 2f;
    private bool canMove;
    private Vector3 moveDirection;
    private AInteractObject lastObjectThatInteract;

    private void Start()
    {
        gameInput = GameInput.getInstance();
    }
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking() { 
        return isWalking;
    }

    private void HandleInteractions() {

        GetObjectThatCollide(out bool isPlayerNear, out AInteractObject interactObject);

        if (interactObject != null && lastObjectThatInteract != null && interactObject != lastObjectThatInteract) {
            lastObjectThatInteract.Interact(false);
        }

        lastObjectThatInteract = interactObject ?? lastObjectThatInteract;

        bool isPlayerInteracting = gameInput.IsInteractionPerformed();

        if (lastObjectThatInteract != null)
        {
            lastObjectThatInteract.Interact(isPlayerNear && isPlayerInteracting);
        }

    }
    private void GetObjectThatCollide( out bool isPlayerNear, out AInteractObject interactObject)
    {
        float interactDistance = PLAYER_WEIGHT;
        interactObject = null;
        isPlayerNear = Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, interactDistance, clearCounterLayerMask);

        if (isPlayerNear) {
            raycastHit.collider.gameObject.TryGetComponent(out interactObject);
        }
        
    }

    private void HandleMovement() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;

        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PLAYER_HEIGHT, PLAYER_RADIUS, moveDirection, moveDistance);

        if (!canMove)
        {

            Vector3 moveDirectionX = new Vector3(inputVector.x, 0, 0).normalized;
            Vector3 moveDirectionZ = new Vector3(0, 0, inputVector.y).normalized;

            bool canMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PLAYER_HEIGHT, PLAYER_RADIUS, moveDirectionX, moveDistance);
            bool canMoveY = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PLAYER_HEIGHT, PLAYER_RADIUS, moveDirectionZ, moveDistance);
            canMove = canMoveX || canMoveY;

            if (canMoveX)
            {
                moveDirection = moveDirectionX;
            }
            else if (canMoveY)
            {
                moveDirection = moveDirectionZ;
            }
        }

        isWalking = moveDirection != Vector3.zero && canMove;

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed); //To get Smoother movement

    }
}
