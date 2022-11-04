using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    // Attractor objects have a ToAttract transform; they will use physics to guide the ToAttract towards its pivot point.

    [SerializeField] private Rigidbody toAttract;
    [SerializeField] float attractStrength = .5f;
    [SerializeField] float massModifier = .5f; // how much mass affects the velocity at which object moves. 
    private Vector3 displacement;
    private float distance;

    private Vector3 targetRotation;
    private Vector3 realRotation;
    private float maxRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetToAttract(Rigidbody rb){
        toAttract = rb;
    }
    public void ClearToAttract(){
        
        toAttract = null;
    }
    void FixedUpdate(){
        // Update to Spring in future!
        if (toAttract != null){
            targetRotation = this.transform.rotation.eulerAngles;
            displacement =  this.transform.position - toAttract.transform.position ;
            toAttract.velocity = displacement*attractStrength/toAttract.mass ;

             toAttract.angularVelocity =  Vector3.SmoothDamp(toAttract.angularVelocity, targetRotation, ref realRotation, Time.smoothDeltaTime, maxRotation );
        }
    }
}
