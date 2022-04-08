using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMove : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;
    public float jumpPower;
    public Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        moveSpeed = 3.0f;
        jumpPower = 5.0f;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.Space)) {
            transform.Translate(Vector3.up * Time.deltaTime * jumpPower);
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Jump");
        }
        else {
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Jump");
            anim.SetTrigger("Stop");
        }
    }
}
