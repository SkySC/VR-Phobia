using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWindSound : MonoBehaviour
{
    private AudioSource windSound;
    // Start is called before the first frame update
    void Start()
    {
        windSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!windSound.isPlaying)
        {
            windSound.volume = Random.Range(0.2f, 0.5f);
            windSound.pitch = Random.Range(0.5f, 1.1f);
            windSound.Play();
        }
    }
}
