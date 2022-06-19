using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWalkingSound : MonoBehaviour
{
    private AudioSource walkingSound;
    private Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        walkingSound = GetComponent<AudioSource>();
        oldPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // dont play sound if only moving up- or downwards
        if (transform.position.y != oldPos.y && transform.position.x == oldPos.x && transform.position.z == oldPos.z) 
            return;
        //oldPos = transform.position;
        // dont play sound if only moving a tiny bit whilest moving up or down
        if (transform.position.y != oldPos.y && Mathf.Abs(transform.position.x - oldPos.x) <= 0.1f && Mathf.Abs(transform.position.z - oldPos.z) <= 0.1f) 
            return;
        // lower the volume if only moving a tiny bit forward or sidewards
        bool smallSteps = false;
        //Debug.Log("delta x = " + Mathf.Abs(transform.position.x - oldPos.x));
        //Debug.Log("delta z = " + Mathf.Abs(transform.position.z - oldPos.z));
        if (Mathf.Abs(transform.position.x - oldPos.x) <= 0.015f && Mathf.Abs(transform.position.z - oldPos.z) <= 0.015f)
            smallSteps = true;

        oldPos = transform.position;

        //Debug.Log("changing position? " + transform.hasChanged);
        if (transform.hasChanged && walkingSound.isPlaying == false)
        {
            transform.hasChanged = false;
            walkingSound.volume = smallSteps ? 0.2f : Random.Range(0.8f, 1);
            walkingSound.pitch = Random.Range(0.8f, 1.1f);
            walkingSound.Play();
        }
    }
}
