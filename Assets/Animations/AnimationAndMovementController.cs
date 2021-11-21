using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;
    int isWalkingHash;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;


    private void Awake() {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");

        playerInput.Movement.Move.started += context => { 
            onMovementInput(context);
        };
        
        playerInput.Movement.Move.canceled += context => { 
            onMovementInput(context);
        };
        playerInput.Movement.Move.performed += context => { 
            onMovementInput(context);
        };
    }

    void handleRotation() {
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        float rotationFactorPerFrame = 15f;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed) {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame*Time.deltaTime);
        }
    
    }


    void handleGravity() {
        if (characterController.isGrounded) {
            float groundedGravity = -0.5f;
            currentMovement.y = groundedGravity;
        } else {
            float gravity = -9.8f;
            currentMovement.y += gravity;
        }
    }

    void handleAnimation() {
        bool isWalking = animator.GetBool(isWalkingHash);
        
        if(isMovementPressed && !isWalking) {
            animator.SetBool(isWalkingHash, true);
        }
        
        else if (!isMovementPressed && isWalking) {
            animator.SetBool(isWalkingHash, false);
        }
    }

    void onMovementInput(InputAction.CallbackContext context) {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        handleRotation();
        handleAnimation();
        handleGravity();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void OnEnable() {
        playerInput.Movement.Enable();
    }

    private void OnDisable() {
        playerInput.Movement.Enable();
    }
}
