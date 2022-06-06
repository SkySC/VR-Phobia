using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFootIK : MonoBehaviour
{
    private Animator animator;
    public Vector3 footOffset;
    [Range(0,1)]
    public float rightFootPosWeight = 1;
    [Range(0,1)]
    public float leftFootPosWeight = 1;
    [Range(0,1)]
    public float rightFootRotWeight = 1;
    [Range(0,1)]
    public float leftFootRotWeight = 1;
    // Start is called before the first frame update
    void Start()
    {
        // get the animation component
        animator = GetComponent<Animator>();
    }

    // automatically called by Animator
    private void OnAnimatorIK(int layerIndex) {
        Vector3 rightFootPos = animator.GetIKPosition(AvatarIKGoal.RightFoot);
        // get the ground position
        RaycastHit hit;
        // check if foot hits the ground
        bool hasHitGround = Physics.Raycast(rightFootPos + Vector3.up, Vector3.down, out hit);
        if (hasHitGround) {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootPosWeight);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footOffset);
            // make sure the foot lays flat on the ground
            Quaternion rightFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootRotWeight);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);
        } else {
            // no ground found --> set weight to 0
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
        }

        Vector3 leftFootPos = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        // check if foot hits the ground
        hasHitGround = Physics.Raycast(leftFootPos + Vector3.up, Vector3.down, out hit);
        if (hasHitGround) {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPosWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footOffset);
            // make sure the foot lays flat on the ground
            Quaternion leftFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootRotWeight);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
        } else {
            // no ground found --> set weigth to 0
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
        }
    }
}
