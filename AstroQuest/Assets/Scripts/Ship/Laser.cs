using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Laser : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.up*20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c){
            Destroy(c.gameObject);
            Destroy(gameObject);
    }
}
