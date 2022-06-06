using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private TMP_Text infoMsg = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            myDoor.Play("DoorOpen", 0, 0.0f);
            if(infoMsg != null)
            {
                infoMsg.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        myDoor.Play("DoorClose", 0, 0.0f);
        if (infoMsg != null)
        {
            infoMsg.gameObject.SetActive(false);
        }
    }
}

//TMP_Text infoMsg = GameObject.Find("Info Message").GetComponent<TMP_Text>();