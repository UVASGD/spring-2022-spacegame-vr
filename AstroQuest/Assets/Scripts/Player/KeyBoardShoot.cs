using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardShoot : MonoBehaviour
{

    public Animator anim;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        damage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Debug.Log("Pressed left click, shooting primary weapon!");
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Shoot");
        }
        if (Input.GetMouseButton(1)) {
            Debug.Log("Pressed right click, shooting secondary weapon!");
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Stop");
            anim.SetTrigger("Shoot");
        }
        else {
            anim.ResetTrigger("Shoot");
            anim.SetTrigger("Stop");
        }
    }
}
