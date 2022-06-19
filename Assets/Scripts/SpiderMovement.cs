using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Animator spiderAnimator;

    void Start()
    {
        spiderAnimator = GetComponent<Animator>();
        if (spiderAnimator != null)
            spiderAnimator.Play("Base Layer.Scene", 0);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, speed * 15 * Time.deltaTime);
    }
}
