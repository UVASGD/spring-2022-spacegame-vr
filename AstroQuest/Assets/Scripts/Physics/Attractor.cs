using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    // Attractor objects have a ToAttract transform; they will use physics to guide the ToAttract towards its pivot point.

    private Rigidbody toAttract;
    [SerializeField] float attractStrength = .5f;
    [SerializeField] float massModifier = .5f; // how much mass affects the velocity at which object moves. 
    private Vector3 displacement;
    private float distance;
    
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
            displacement =  this.transform.position - toAttract.transform.position ;
            toAttract.velocity = displacement*attractStrength/toAttract.mass ;
        }
    }
}
