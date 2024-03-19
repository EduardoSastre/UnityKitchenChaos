using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Player : AInteractable
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask clearCounterLayerMask;

    private bool isWalking;
    private bool canMove;

    private const float PLAYER_RADIUS = 0.7f;
    private const float INTERACT_DISTANCE = PLAYER_RADIUS*3;
    private const float PLAYER_HEIGHT = 2f;
    
    private Vector3 moveDirection;
    private AInteractable lastObjectThatInteract;
    private SelectedCounterVisual selectedCounterVisual;
    private bool isInteractableObjectNear;

    private void Start()
    {
        gameInput = GameInput.getInstance();
        selectedCounterVisual = gameObject.AddComponent<SelectedCounterVisual>();
        SetPickPoint();
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

        AInteractable currentObject = GetObjectThatCollide();

        lastObjectThatInteract = currentObject ?? lastObjectThatInteract;

        bool shouldPerformVisual = gameInput.IsInteractionPerformed();
        bool isPlayerInteracting = gameInput.IsInteractionPressed();

        if (shouldPerformVisual && !CheckObject.isNullOrEmpty(currentObject) )
        {
            //lastObjectThatInteract.Interact(this);
            selectedCounterVisual.setCounter(lastObjectThatInteract);
            
        }
        selectedCounterVisual.setShouldInteract(isInteractableObjectNear);

        if (isPlayerInteracting && !CheckObject.isNullOrEmpty(currentObject))
        {
            lastObjectThatInteract.Interact(this);

        }

    }
    private AInteractable GetObjectThatCollide()
    {
        AInteractable interactObject = null;

        isInteractableObjectNear = Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, INTERACT_DISTANCE, clearCounterLayerMask);

        if (isInteractableObjectNear) {
            raycastHit.collider.gameObject.TryGetComponent(out interactObject);
        }
        
        return interactObject;
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

    public override void Interact(AInteractable interactableObject)
    {
        
    }

    public override void CancelInteract()
    {
        throw new NotImplementedException();
    }
}
