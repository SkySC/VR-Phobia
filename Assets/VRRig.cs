using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// match position of head to headset
[System.Serializable]
public class VRMap {
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map() {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    public Transform headConstraint;
    // difference in position between head & body
    public Vector3 headBodyOffset;
    // turn smoother
    public float turnSmoothness;

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    void FixedUpdate()
    {
        // move body in the direction the head is pointing towards
        transform.position = headConstraint.position + headBodyOffset;
        // only rotate on y-axis, put a delay on rotation of the body, so that the head rotates first
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
