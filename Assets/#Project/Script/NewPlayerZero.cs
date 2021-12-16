using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerZero : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 30f;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float animationSmoothTime = 0.1f;
    [SerializeField]
    public float animationPlayerTransition = 0.15f;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    private InputAction moveAction;
    // private InputAction lookAction;
    public Camera playerCam;
    public Animator animator;
    int moveXAnimationParameterId;
    int moveZAnimationParameterId;
    Vector2 currentAnimationBlendVector;
    public Vector2 animationVelocity;
    public int victoryAnimation;
    //public Door door;
    public MenuGame_Manager menuGame_Manager;
    public float timeAnimVictory = 5.0f;
    

    private bool isBack = false;
    
    private void Awake()
    {
        menuGame_Manager = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
        animator = GetComponentInChildren<Animator>();
        if(animator == null)
        {
            Debug.Log("animator null");
        }
        else{
            Debug.Log("animator ok");
        }
        //door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
        playerCam= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;

        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        // cameraTransform = Camera.main.transform;
        cameraTransform = playerCam.transform;
        moveAction = playerInput.actions["Move"];

        //Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInChildren<Animator>();
        victoryAnimation = Animator.StringToHash("Victory");
        moveXAnimationParameterId = Animator.StringToHash("MoveX");
        moveZAnimationParameterId = Animator.StringToHash("MoveZ");
        animator.SetFloat(moveXAnimationParameterId, 0f);
    }
    

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity,animationSmoothTime);


        Vector3 move = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);
        //Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z *cameraTransform.forward.normalized;
        move.y =0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        animator.SetFloat(moveXAnimationParameterId, currentAnimationBlendVector.x);
        animator.SetFloat(moveZAnimationParameterId, currentAnimationBlendVector.y);


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //rotation
        Quaternion targetRotation = Quaternion.LookRotation(move);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);

        //transform.rotation = transform.LookAt(transform.position  + GameObject.GetComponent<RigidBody>().velocity);

        // if(door.doorIsOpen)
        // {
        //     animator.CrossFade(victoryAnimation, animationPlayerTransition);
        // }
    }
    public void MiaoVictoryAnimation()
    {
        animator.SetTrigger("Victory"); 
    }
    
}
