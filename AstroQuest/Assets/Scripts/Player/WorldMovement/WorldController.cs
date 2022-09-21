using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Vector3 velocity;
    bool canMove;
    [SerializeField] float normalSpeed = 8;
    [SerializeField] float boostSpeed = 13;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        
        float curSpeedX = canMove ? (isRunning ? normalSpeed : boostSpeed) * Input.GetAxis("Debug Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? normalSpeed : boostSpeed) * Input.GetAxis("Debug Horizontal") : 0;
        float movementDirectionY = velocity.y;
        velocity = (forward * curSpeedX) + (right * curSpeedY);

    }
    void FixedUpdate()
    {
        rb.velocity = -1*velocity; // since we want to move world backwards relative to static objects.
    }
}
