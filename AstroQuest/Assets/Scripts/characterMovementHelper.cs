using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class characterMovementHelper : MonoBehaviour
{
    private XROrigin XROrigin;
    private CapsuleCollider capsuleCollider;
    [SerializeField] Transform PlayerRoot;

    private CharacterControllerDriver driver;

    void Start(){
        XROrigin = GetComponent<XROrigin>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    void Update(){
        UpdateCharacterController();
    }
        /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        // update Capsule
        if (XROrigin == null || capsuleCollider == null)
            return;

        var height = Mathf.Clamp(XROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f;

        capsuleCollider.height = height;
        capsuleCollider.center = center;

        // update PlayerRoot (arms)
        
        center.y = height;
        var rotation = XROrigin.Camera.transform.rotation;

        PlayerRoot.transform.localPosition = center;
        PlayerRoot.transform.localRotation= rotation;

    }

}
