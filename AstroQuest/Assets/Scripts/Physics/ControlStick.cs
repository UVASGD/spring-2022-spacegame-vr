using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStick : MonoBehaviour
{
    Attractor attractorAnchor;
    Rigidbody grabbable;
    // Start is called before the first frame update
    void Start()
    {
        attractorAnchor = GetComponentInChildren<Attractor>();
        attractorAnchor.SetToAttract(grabbable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 GetValue(){
        return new Vector2(grabbable.transform.rotation.x,grabbable.transform.rotation.z );
    }
}
