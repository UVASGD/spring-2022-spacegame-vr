using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShipGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject laserPrefab;

    [SerializeField] Autohand.PhysicsGadgetButton button;

    [SerializeField] Transform gun1Pos;
    [SerializeField] Transform gun2Pos;

    [SerializeField] Transform world;

    Transform firingOrigin;
    void Start()
    {
        button.OnPressed.AddListener(Fire);
        firingOrigin = gun1Pos;
    }

    void Fire(){
        if(firingOrigin == gun1Pos){
            firingOrigin = gun2Pos;
        }else{
            firingOrigin = gun1Pos;
        }
        GameObject laser = Instantiate(laserPrefab, firingOrigin.position, Quaternion.identity) as GameObject;
        laser.transform.SetParent(world);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
