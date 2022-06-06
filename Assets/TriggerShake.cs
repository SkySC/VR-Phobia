using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShake : MonoBehaviour
{
    [SerializeField] private float shakeStartDelay = 1.0f;
    [SerializeField] private float shakeInterval = 2.0f;

    private ScreenShakeVR screenShake = null;
    private BoxCollider boxCollider = null;
    // Start is called before the first frame update
    void Start()
    {
        screenShake = Camera.main.GetComponent<ScreenShakeVR>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kyle entered the bridge");
            // enable repeated invoke
            screenShake.InvokeRepeating("Shake", shakeStartDelay, shakeInterval);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kyle left the bridge");
            // disable repeated invoke
            screenShake.CancelInvoke();
        }
    }
}
