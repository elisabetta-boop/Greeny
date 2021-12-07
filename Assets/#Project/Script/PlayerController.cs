using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private GameObject prefabMegaBullet;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private float bulletHitMissDistance = 25f;
    [SerializeField]
    private float animationSmoothTime = 0.1f;
    [SerializeField]
    private float animationPlayerTransition = 0.15f;
    [SerializeField]
    private Transform aimTarget;
    [SerializeField]
    private float aimDistance = 1f;
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    private InputAction moveAction;
    // private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction megaShootAction;
    public LayerMask shootLayer;
    public ParticleSystemShoot shootPaint;

    public PlayerManager playerManager;
    public PaintFuelManager paintFuelManager;
    public UnityEvent whenMegaShoot;
    
    

    private Animator animator;
    int RecoilAnimation;
    int jumpAnimation;
    int moveXAnimationParameterId;
    int moveZAnimationParameterId;

    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        // lookAction = playerInput.actions["Look"];
        shootAction = playerInput.actions["Shoot"];
        megaShootAction = playerInput.actions["MegaShoot"];
        
        Cursor.lockState = CursorLockMode.Locked;
       

        animator = GetComponentInChildren<Animator>();
        jumpAnimation = Animator.StringToHash("Pistol Jump");
        RecoilAnimation = Animator.StringToHash("Pistol Recoil");
        moveXAnimationParameterId = Animator.StringToHash("MoveX");
        moveZAnimationParameterId = Animator.StringToHash("MoveZ");
        animator.SetFloat(moveXAnimationParameterId, 0f);
    }
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        
        if(paintFuelManager == null)
        {
            paintFuelManager = GameObject.FindGameObjectWithTag("PaintFuelManager").GetComponent<PaintFuelManager>();
        }
        
        
    }
    private void OnEnable()
    {
        shootAction.performed += _ => ShootGun();
        
        megaShootAction.performed += _ => MegaShootGun();
        
    }
    private void OnDisable()
    {
        shootAction.performed -= _ => ShootGun();
        megaShootAction.performed -= _ => MegaShootGun();
    }
    private void ShootGun()
    {
        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(prefabBullet,barrelTransform.position, Quaternion.identity,bulletParent);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity, shootLayer)) //at the end I can put a layer mask
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
            shootPaint.particles = true;
            
        }
        else{
            bulletController.target = cameraTransform.position + cameraTransform.forward*bulletHitMissDistance;
            bulletController.hit = false;
        }
        animator.CrossFade(RecoilAnimation, animationPlayerTransition);
    }
    private void MegaShootGun()
    {

        if(paintFuelManager.paintFuel < 100)
        {
            return;
        }

        RaycastHit megaHit;
        GameObject megaBullet = GameObject.Instantiate(prefabMegaBullet,barrelTransform.position, Quaternion.identity,bulletParent);

        paintFuelManager.paintFuelLess();
        //whenMegaShoot?.Invoke();

        MegaBulletController megaBulletController = megaBullet.GetComponent<MegaBulletController>();

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out megaHit, Mathf.Infinity, shootLayer)) //at the end I can put a layer mask
        {
            megaBulletController.target = megaHit.point;
            megaBulletController.megaHit = true;
            //shootPaint.particles = true;
            
        }
        else{
            megaBulletController.target = cameraTransform.position + cameraTransform.forward*bulletHitMissDistance;
            megaBulletController.megaHit = false;
        }
    }

    void Update()
    {
        
        aimTarget.position = cameraTransform.position + cameraTransform.forward * aimDistance;

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

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }

        animator.SetFloat(moveXAnimationParameterId, currentAnimationBlendVector.x);
        animator.SetFloat(moveZAnimationParameterId, currentAnimationBlendVector.y);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.CrossFade(jumpAnimation, animationPlayerTransition);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //rotation
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y,0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    
    
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.Events;

// [RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
// public class PlayerController : MonoBehaviour
// {
//     [SerializeField]
//     private float playerSpeed = 2.0f;
//     [SerializeField]
//     private float jumpHeight = 1.0f;
//     [SerializeField]
//     private float gravityValue = -9.81f;
//     [SerializeField]
//     private float rotationSpeed = 5f;
//     [SerializeField]
//     private GameObject prefabBullet;
//     [SerializeField]
//     private GameObject prefabMegaBullet;
//     [SerializeField]
//     private Transform barrelTransform;
//     [SerializeField]
//     private Transform bulletParent;
//     [SerializeField]
//     private float bulletHitMissDistance = 25f;
//     [SerializeField]
//     // private float animationSmoothTime = 0.1f;
//     // [SerializeField]
//     // private float animationPlayerTransition = 0.15f;
//     // [SerializeField]
//     // private Transform aimTarget;
//     // [SerializeField]
//     // private float aimDistance = 1f;
//     private CharacterController controller;
//     private PlayerInput playerInput;
//     private Vector3 playerVelocity;
//     private bool groundedPlayer;
//     private Transform cameraTransform;
//     private InputAction moveAction;
//     // private InputAction lookAction;
//     private InputAction jumpAction;
//     private InputAction shootAction;
//     private InputAction megaShootAction;
//     public LayerMask shootLayer;
//     public ParticleSystemShoot shootPaint;

//     public PlayerManager playerManager;
//     public PaintFuelManager paintFuelManager;
//     public UnityEvent whenMegaShoot;
    
    

//     // private Animator animator;
//     // int RecoilAnimation;
//     // int jumpAnimation;
//     // int moveXAnimationParameterId;
//     // int moveZAnimationParameterId;

//     // Vector2 currentAnimationBlendVector;
//     // Vector2 animationVelocity;
    
//     private void Awake()
//     {
//         controller = GetComponent<CharacterController>();
//         playerInput = GetComponent<PlayerInput>();
//         cameraTransform = Camera.main.transform;
//         moveAction = playerInput.actions["Move"];
//         jumpAction = playerInput.actions["Jump"];
//         // lookAction = playerInput.actions["Look"];
//         shootAction = playerInput.actions["Shoot"];
//         megaShootAction = playerInput.actions["MegaShoot"];
        
//         Cursor.lockState = CursorLockMode.Locked;
       

//         // animator = GetComponent<Animator>();
//         // jumpAnimation = Animator.StringToHash("Pistol Jump");
//         // RecoilAnimation = Animator.StringToHash("PistolShootRecoil");
//         // moveXAnimationParameterId = Animator.StringToHash("MoveX");
//         // moveZAnimationParameterId = Animator.StringToHash("MoveZ");
//         //animator.SetFloat(moveXAnimationParameterId, 1f);
//     }
//     void Start()
//     {
//         playerManager = GetComponent<PlayerManager>();
        
//         if(paintFuelManager == null)
//         {
//             paintFuelManager = GameObject.FindGameObjectWithTag("PaintFuelManager").GetComponent<PaintFuelManager>();
//         }
        
        
//     }
//     private void OnEnable()
//     {
//         shootAction.performed += _ => ShootGun();
        
//         megaShootAction.performed += _ => MegaShootGun();
        
//     }
//     private void OnDisable()
//     {
//         shootAction.performed -= _ => ShootGun();
//         megaShootAction.performed -= _ => MegaShootGun();
//     }
//     private void ShootGun()
//     {
//         RaycastHit hit;
//         GameObject bullet = GameObject.Instantiate(prefabBullet,barrelTransform.position, Quaternion.identity,bulletParent);
//         BulletController bulletController = bullet.GetComponent<BulletController>();
//         if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity, shootLayer)) //at the end I can put a layer mask
//         {
//             bulletController.target = hit.point;
//             bulletController.hit = true;
//             shootPaint.particles = true;
            
//         }
//         else{
//             bulletController.target = cameraTransform.position + cameraTransform.forward*bulletHitMissDistance;
//             bulletController.hit = false;
//         }
//     }
//     private void MegaShootGun()
//     {

//         if(paintFuelManager.paintFuel < 100)
//         {
//             return;
//         }

//         RaycastHit megaHit;
//         GameObject megaBullet = GameObject.Instantiate(prefabMegaBullet,barrelTransform.position, Quaternion.identity,bulletParent);

//         paintFuelManager.paintFuelLess();
//         //whenMegaShoot?.Invoke();

//         MegaBulletController megaBulletController = megaBullet.GetComponent<MegaBulletController>();

//         if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out megaHit, Mathf.Infinity, shootLayer)) //at the end I can put a layer mask
//         {
//             megaBulletController.target = megaHit.point;
//             megaBulletController.megaHit = true;
//             //shootPaint.particles = true;
            
//         }
//         else{
//             megaBulletController.target = cameraTransform.position + cameraTransform.forward*bulletHitMissDistance;
//             megaBulletController.megaHit = false;
//         }
//     }

//     void Update()
//     {
        
    

//         groundedPlayer = controller.isGrounded;
//         if (groundedPlayer && playerVelocity.y < 0)
//         {
//             playerVelocity.y = 0f;
//         }

//         Vector2 input = moveAction.ReadValue<Vector2>();
//         //currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity,animationSmoothTime);


//        // Vector3 move = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);
//         Vector3 move = new Vector3(input.x, 0, input.y);
//         move = move.x * cameraTransform.right.normalized + move.z *cameraTransform.forward.normalized;
//         move.y =0f;
//         controller.Move(move * Time.deltaTime * playerSpeed);

//         // if (move != Vector3.zero)
//         // {
//         //     gameObject.transform.forward = move;
//         // }

//         //animator.SetFloat(moveXAnimationParameterId, currentAnimationBlendVector.x);
//         //animator.SetFloat(moveZAnimationParameterId, currentAnimationBlendVector.y);

//         // Changes the height position of the player..
//         if (jumpAction.triggered && groundedPlayer)
//         {
//             playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
//             //animator.CrossFade(jumpAnimation, animationPlayerTransition);
//         }

//         playerVelocity.y += gravityValue * Time.deltaTime;
//         controller.Move(playerVelocity * Time.deltaTime);

//         //rotation
//         Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y,0);
//         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//     }
    
    
// }


