using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyRotation : MonoBehaviour
{
     // Start is called before the first frame update
    [SerializeField] Transform toCopy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.rotation = toCopy.transform.rotation;
    }
}
