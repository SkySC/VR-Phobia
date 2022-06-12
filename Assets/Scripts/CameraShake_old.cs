using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKey("down")) {
            StartCoroutine(Shake(.15f, .4f));
        }
    }

    IEnumerator Shake (float duration, float strength) {
        Vector3 originalPos = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration) {
            float x = originalPos.x + Random.Range(-1f, 1f) * strength;
            float y = originalPos.y + Random.Range(-1f, 1f) * strength;

                        
            Vector3 _lastRotation = new Vector3(
                5f * (Mathf.PerlinNoise(3, Time.time * 25) * 2 - 1),
                5f * (Mathf.PerlinNoise(4, Time.time * 25) * 2 - 1),
                transform.localRotation.z
            ) * strength;
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles - _lastRotation);

            transform.localPosition = new Vector3(x, y, originalPos.z);
            timeElapsed += Time.deltaTime;
            // wait until next frame is drawn
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}