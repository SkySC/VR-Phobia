using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class SwitchToLevelpickerScene : MonoBehaviour
{
    [SerializeField] private XRController leftHandController;
    [SerializeField] private UnityEvent OnTriggerPressed;

    void Update()
    {
        bool buttonPressed;
        // check for button press & assign to bool
        //leftHandController.inputDevice.IsPressed(button, out buttonPressed);
        leftHandController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out buttonPressed);
        if (buttonPressed)
        {
            SceneManager.LoadScene(sceneName: "LevelpickerScene");
        }

        if (currentInteractor.GetComponent<ActionBasedController>().activateAction.action.ReadValue<float>() > 0.5f)
        {
            Debug.Log("trigger pressed");
        }
    }
}
