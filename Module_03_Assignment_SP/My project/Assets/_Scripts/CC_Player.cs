using UnityEngine;
using UnityEngine.InputSystem;

public class CC_Player : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform playerRoot;

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float lookSpeed = 10f;

    [Header("Physics")]
    public float pushForce = 1.5f;
    public float gravityForce = -20f;
    public float stickForce = -2f;

    //Private vars
    private InputAction IA_Move, IA_Look; 
    private Vector3 moveInput;
    private Vector3 moveVector;
    private Vector2 lookVector;
    private float cameraPitch;
    private float cameraPitchMin = -75f;
    private float cameraPitchMax = 75f;
    private float gravity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = playerRoot.TransformDirection(moveInput);
        Vector3 velocity = new Vector3(moveVector.x, moveVector.y + gravity, moveVector.z);
        controller.Move(velocity * moveSpeed * Time.deltaTime);

        playerRoot.Rotate(Vector3.up, lookVector.x * lookSpeed * Time.deltaTime);

        cameraPitch -= lookVector.y * lookSpeed * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, cameraPitchMin, cameraPitchMax);
        playerCamera.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);

        //Gravity
        bool grounded = controller.isGrounded;
        if (grounded && gravity < 0f) gravity = stickForce;
        else gravity += gravityForce * Time.deltaTime;
    }

    //Binded Input Methods
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = new Vector3(ctx.ReadValue<Vector2>().x , 0f, ctx.ReadValue<Vector2>().y);
    }
    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookVector = ctx.ReadValue<Vector2>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log (hit);
        Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0f, hit.moveDirection.z);
        body.AddForce(pushDir * pushForce, ForceMode.Impulse);

    }
}
