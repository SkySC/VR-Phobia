using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    Material skyboxMaterial;
    // Start is called before the first frame update
    void Start()
    {
        skyboxMaterial = RenderSettings.skybox;
        Debug.Log("Skybox rot value = " + skyboxMaterial.shader);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentRotation = skyboxMaterial.GetFloat("_Rotation");
        skyboxMaterial.SetFloat("_Rotation", currentRotation + 0.005f);
        DynamicGI.UpdateEnvironment();
    }

    void OnApplicationQuit()
    {
        skyboxMaterial.SetFloat("_Rotation", 0);
        DynamicGI.UpdateEnvironment();
    }
}
