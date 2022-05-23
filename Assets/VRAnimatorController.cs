using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    public float speedTreshold = 0.1f;
    [Range(0,1)]
    public float smoothing = 1;
    private Animator animator;
    private Vector3 prevPos;
    // reference to VR Rig --> VR headset reference
    private VRRig vrRig;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        prevPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        // compute the speed
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - prevPos) / Time.deltaTime;
        // only horizontal speed is needed
        headsetSpeed.y = 0;
        // speed according to the direction of the player
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        prevPos = vrRig.head.vrTarget.position;

        // smoothen movement
        float prevDirectionX = animator.GetFloat("DirectionX");
        float prevDirectionY = animator.GetFloat("DirectionY");
        // set Animator values
        animator.SetBool("isMoving", headsetLocalSpeed.magnitude > speedTreshold);
        animator.SetFloat("DirectionX", Mathf.Lerp(prevDirectionX, Mathf.Clamp(headsetLocalSpeed.x, -1, 1), smoothing));
        // no vertical speed --> choose z-axis
        animator.SetFloat("DirectionY", Mathf.Lerp(prevDirectionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1), smoothing));
    }
}
