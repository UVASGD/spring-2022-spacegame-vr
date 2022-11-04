using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] private Vector3 targetVelocity = Vector3.zero;
    [SerializeField] private Vector3 realRotation; // Euler angles

    [SerializeField] private float velocityDecay = .05f; // ratio of how much velocity is reduced per frame
    
    [SerializeField] private Vector3 targetPosition; // position where World will be next frame, updated by current rotation.

    [SerializeField] private Vector3 targetRotation; // Euler angles
    [SerializeField] private Quaternion lastFrameRotation; // Last Frame's this.transform.forward vector.
    [SerializeField] private Quaternion deltaRotation;
    [SerializeField] Rigidbody rb;

    [SerializeField] Rigidbody worldDisplacementBody;
    [SerializeField] private Vector3 realVelocity;
    Vector3 recordedVelocity;
    [SerializeField] Vector3 rotatedVelocity;
    bool canMove;
    [SerializeField] Autohand.PhysicsGadgetJoystick joystick;
    [SerializeField] Autohand.PhysicsGadgetConfigurableLimitReader thrust;

    [SerializeField] float controlStrengthX = .1f;
    [SerializeField] float controlStrengthY = .16f;
    [SerializeField] float thrustStrength = .1f;

    [SerializeField] float maxSpeed = 100;
    [SerializeField] float maxRotation = 20;
    // Start is called before the first frame update
    void Start()
    {
        lastFrameRotation = Quaternion.identity;
        canMove = true;
        targetPosition = worldDisplacementBody.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation.z = joystick.GetValue().x*controlStrengthY;
        targetRotation.x =  joystick.GetValue().y*controlStrengthX;
        
    }

    void move(Vector3 targetPosition){
       // worldDisplacementBody.velocity = momentumRotation*Vector3.SmoothDamp(worldDisplacementBody.velocity, targetPosition, ref realVelocity, Time.smoothDeltaTime, maxSpeed);


       
        rb.angularVelocity = Vector3.SmoothDamp(rb.angularVelocity, targetRotation, ref realRotation, Time.smoothDeltaTime,maxRotation);
        // rb.AddTorque(Vector3.SmoothDamp(Vector3.zero, targetRotation, ref realRotation, Time.smoothDeltaTime,maxRotation), ForceMode.Impulse);
        
        
        worldDisplacementBody.velocity = realVelocity;
       
    }
 
    void FixedUpdate(){
        deltaRotation = this.transform.rotation*Quaternion.Inverse(lastFrameRotation);
        targetPosition =  (Vector3.forward)*thrust.GetValue()*thrustStrength ;
        realVelocity = (deltaRotation*realVelocity)+targetPosition -(realVelocity*velocityDecay);
        Debug.DrawLine(Vector3.zero, worldDisplacementBody.velocity, Color.red);
        Debug.DrawLine(Vector3.zero, realVelocity, Color.cyan);
        Debug.DrawLine(Vector3.zero, Vector3.forward, Color.yellow);
        move(targetPosition);
        
        lastFrameRotation = this.transform.rotation;
    }
}
