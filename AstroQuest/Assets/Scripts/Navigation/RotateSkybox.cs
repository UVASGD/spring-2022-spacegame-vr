using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateSkybox : MonoBehaviour
{
    
    [SerializeField] Material skyboxMaterial;
    [SerializeField] Vector3 rotAxis;
    [SerializeField] float rotAngle;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //convert euler to axis-angle https://www.euclideanspace.com/maths/geometry/rotations/conversions/eulerToAngle/
        // float c1 = Mathf.Cos(transformRotation.z/2);
        // float c2 = Mathf.Cos(transformRotation.y/2);
        // float c3 = Mathf.Cos(transformRotation.x/2);
        // float s1 = Mathf.Sin(transformRotation.z/2);
        // float s2 = Mathf.Sin(transformRotation.y/2);
        // float s3 = Mathf.Sin(transformRotation.x/2);
        transform.rotation.ToAngleAxis(out rotAngle, out rotAxis);

       // Debug.DrawLine(transform.position, transform.position+Vector3.up, Color.red);
        // Debug.DrawLine(transform.position, transform.position+transformRotation, Color.blue);
        // Debug.DrawLine(transform.position, transform.position +rotationVector, Color.cyan);

         //set the rotation for the skybox shader
        
        
        Quaternion rot = Quaternion.Euler (0, 1, 0); 
        Matrix4x4 m = new Matrix4x4 ();
        m.SetTRS(Vector3.zero, rot,new Vector3(1,1,1) );
        skyboxMaterial.SetFloat ("_Rotation", rotAngle);
        skyboxMaterial.SetVector("_RotationAxis", new Vector4(rotAxis.x,rotAxis.y,rotAxis.z,0));

    }
}
