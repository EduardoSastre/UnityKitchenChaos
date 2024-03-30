using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Player : AInteractable
{

    public event EventHandler<OnCounterInteractionEventsArgs> OnCounterInteraction;

    public class OnCounterInteractionEventsArgs : EventArgs { 
        public ABaseCounter counter;
        public Player player;
    }

    private static Player player;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask clearCounterLayerMask;

    private bool isWalking;
    private bool canMove;

    private const float PLAYER_RADIUS = 0.7f;
    private const float INTERACT_DISTANCE = PLAYER_RADIUS*3;
    private const float PLAYER_HEIGHT = 2f;

    private Vector3 moveDirection;
    private ABaseCounter lastCounterThatInteract;

    private void Awake()
    {
        player = this;
    }

    private void Start()
    {
        gameInput = GameInput.GetInstance();
        SetPickPoint();
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        HandleInteractions();
    }

    private void Update()
    {
        HandleMovement();
        lastCounterThatInteract = GetObjectThatCollide();
    }

    public bool IsWalking() { 
        return isWalking;
    }

    private void HandleInteractions() {

        ABaseCounter currentObject = GetObjectThatCollide();

        OnCounterInteraction?.Invoke(this, new OnCounterInteractionEventsArgs { counter = currentObject, player = this });

    }
    public ABaseCounter GetObjectThatCollide()
    {
        ABaseCounter interactObject = null;

        bool isInteractableObjectNear = Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, INTERACT_DISTANCE, clearCounterLayerMask);

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

    public static Player GetInstance() {
        return player;
    }
}
