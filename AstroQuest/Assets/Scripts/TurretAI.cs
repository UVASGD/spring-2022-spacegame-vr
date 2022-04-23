using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [SerializeField] private Transform target; // current target
    private Vector3 lastTarget; // last target position
    private Transform parent; // turret base, use to determine direction
    [SerializeField] private float range; // max detection distance
    [SerializeField] private float rotateSpeed; // turret traverse speed (degrees)
    [SerializeField] private float accuracy; // percent accuracy
    
    void Start()
    {
        parent = transform.parent;
        lastTarget = target.position;
        rotateSpeed = rotateSpeed * Mathf.PI / 180f;
    }

    void Update()
    {
        // Acquire Target
        // Debug.Log(target.position);
        // TODO check tag and range

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > range)
            return;

        // Lead Target "Velocity"
        // just use RB velocity if available
        Vector3 velocity = target.position - lastTarget;

        // Point at Target Position
        // Calculate pitch (elevation) and yaw (latitude) angles
        // Don't want to roll the turret
        // TODO: +x direction is not turret forward

        Vector3 direction = ((target.position + velocity) - transform.position); // target direction
        // TODO clamp rotation

        Vector3 pitch = Vector3.ProjectOnPlane(direction, parent.up);
        Vector3 yaw = Vector3.ProjectOnPlane(direction, parent.right);

        Vector3 turret = transform.forward;
        Vector3.RotateTowards(turret, pitch, rotateSpeed * Time.deltaTime, 0);
        Vector3.RotateTowards(turret, yaw, rotateSpeed * Time.deltaTime, 0);
        transform.LookAt(direction, parent.up);

        // Fire if pointing at target
        // TODO Factor in Accuracy
        Debug.Log("pew");

        // Reset last target
        lastTarget = target.position;
    }
}
