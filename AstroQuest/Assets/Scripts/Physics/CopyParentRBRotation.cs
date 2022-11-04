using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CopyParentRBRotation : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody childRB;
    Rigidbody parentRB;
    void Start()
    {
        childRB = this.GetComponent<Rigidbody>();
        parentRB = this.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        childRB.angularVelocity = parentRB.angularVelocity;
    }
}
