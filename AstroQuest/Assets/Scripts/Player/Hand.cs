using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{

    //Animation
    public float animationSpeed;
    private Animator _animator;
    private SkinnedMeshRenderer _mesh;
    private float _gripTarget;
    private float _triggerTarget;
    private float _gripCurrent;
    private float _triggerCurrent;
    private const string AnimatorGripParam = "Grip";
    private const string AnimatorTriggerParam = "Trigger";
    private static readonly int Grip = Animator.StringToHash(AnimatorGripParam);
    private static readonly int Trigger = Animator.StringToHash(AnimatorTriggerParam);

    //PhysicsMovement
    [SerializeField] private GameObject followObject;

    [SerializeField] private GameObject IKTip; // ArmConstraint Target
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed =100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;

    void Start()
    {
        //Animation
        _animator = this.GetComponent<Animator>();
        _mesh = this.GetComponentInChildren<SkinnedMeshRenderer>();

        //Physics Movement
        _followTarget = followObject.transform;
        _body = IKTip.GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        // Teleport hands
        // TODO
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
        
    }
    void LateUpdate(){
        //PhysicsMove();
    }

    

    internal void SetGrip(float v)
    {
        _gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        _triggerTarget = v;
    }
    private void AnimateHand()
    {
        if (_gripCurrent != _gripTarget){
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
            _animator.SetFloat(AnimatorGripParam, _gripCurrent);
        }
        if (_triggerCurrent != _triggerTarget){
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
            _animator.SetFloat(AnimatorTriggerParam, _triggerCurrent);
        }
    }
    private void PhysicsMove()
    {
        // update position
        Vector3 positionWithOffset = _followTarget.TransformPoint(positionOffset);
        float distance = Vector3.Distance(positionWithOffset, IKTip.transform.position);

        _body.velocity = (positionWithOffset - IKTip.transform.position).normalized * (followSpeed * distance);
        //IKTip.transform.position = positionOffset;
        
       
        // update rotation
        Quaternion rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset); 
        Quaternion q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

    }

}
