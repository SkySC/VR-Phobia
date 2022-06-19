using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

// attach it to a new GameObject ?
public class SwitchToLevelpickerScene : MonoBehaviour
{
    private List<InputDevice> leftHandedDevices = new List<InputDevice>();
    private InputDevice leftHandTargetDevice;

    /*
    // approach 1
    void FixedUpdate()
    {
        if (leftHandedDevices.Count <= 0)
        {
            InputDevices.GetDeviceAtXRNode(XRNode.LeftHand, out leftHandedDevices);
            Debug.Log("devices found = " + leftHandedDevices.Count);
            foreach (var device in leftHandedDevices)
                Debug.Log(string.Format("device name = " + device.name + " device role = " + device.characteristics));

            if (leftHandedDevices.Count > 0)
                leftHandTargetDevice = leftHandedDevices[0];
        }

        bool touchpadPressed;
        // checking for a press on the trackpad
        bool couldGetFeatureValue = leftHandTargetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out touchpadPressed);

        if (couldGetFeatureValue && touchpadPressed)
            SceneManager.LoadScene(sceneName: "LevelpickerScene");
    }
    */

    /*
    // approach 2
    void Start()
    {
        Debug.Log("Start");
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, leftHandedDevices);

        foreach (var device in leftHandedDevices)
            Debug.Log(string.Format("Start: device name = " + device.name + " device role = " + device.characteristics));

        if(leftHandedDevices.Count > 0)
            leftHandTargetDevice = leftHandedDevices[0];
    }
    */

    void FixedUpdate()
    {
        if (!leftHandTargetDevice.isValid)
        {

            InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left /*| InputDeviceCharacteristics.Controller*/;
            InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, leftHandedDevices);

            foreach (var device in leftHandedDevices)
                Debug.Log(string.Format("device name = " + device.name + " device role = " + device.characteristics));

            if (leftHandedDevices.Count > 0)
                leftHandTargetDevice = leftHandedDevices[0];
        }

        bool touchpadPressed;
        // checking for a press on the trackpad
        bool couldGetFeatureValue = leftHandTargetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out touchpadPressed);

        if (couldGetFeatureValue && touchpadPressed)
            SceneManager.LoadScene(sceneName: "LevelpickerScene");
    }
}
