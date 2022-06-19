using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneSound : MonoBehaviour
{
    private AudioSource sceneSound;
    // Start is called before the first frame update
    void Start()
    {
        sceneSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!sceneSound.isPlaying)
        {
            sceneSound.volume = Random.Range(0.2f, 0.5f);
            sceneSound.pitch = Random.Range(0.5f, 1.1f);
            sceneSound.Play();
        }
    }
}
