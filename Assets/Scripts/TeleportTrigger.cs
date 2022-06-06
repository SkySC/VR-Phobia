using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private string scene = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && scene != null)
        {
            SceneManager.LoadScene(sceneName: scene);
        }
    }
}