using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] Vector3 rotation_amt;
    [SerializeField] private float tumble;

    void Start()
    {
        
    }
    void Awake()
    {
        rotation_amt  = Random.insideUnitSphere * tumble;
    }

    void LateUpdate(){
        this.transform.Rotate(rotation_amt);
    }
}