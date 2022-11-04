using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] Camera testPlayerCamera;
    [SerializeField] Vector3 mousePos;

    public float lookSpeed = 2.0f;
    Vector3 moveDirection = Vector3.zero;
    [HideInInspector]
    public bool canMove = true;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    private CharacterController testPlayerController;
    private Attractor testAttractor;
    private bool isHolding = false;

    float rotationX;
    // Start is called before the first frame update
    void Start()
    {
        testPlayerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        testPlayerController = GetComponentInChildren<CharacterController>();
        testAttractor = GetComponentInChildren<Attractor>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate movement based on WASD controls
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

       

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        testPlayerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        // if left click
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            // if there is interactable object on cursor
            if (Physics.Raycast(testPlayerCamera.transform.position,testPlayerCamera.transform.TransformDirection(Vector3.forward), out hit, 8f, LayerMask.GetMask("Interactable")))
            {
                testAttractor.transform.position = hit.transform.position;
                testAttractor.SetToAttract(hit.rigidbody);
                isHolding = true;
            }

            if(isHolding){
                Debug.DrawRay(testPlayerCamera.transform.position, testPlayerCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            }
            else{
                 Debug.DrawRay(testPlayerCamera.transform.position, testPlayerCamera.transform.TransformDirection(Vector3.forward) * 5f, Color.yellow);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)){
            isHolding = false;
            testAttractor.ClearToAttract();
        }
    }
    void FixedUpdate()
    {
        testPlayerController.Move(moveDirection * Time.deltaTime);
        
    }
}
