using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSound : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("rna");
            FindObjectOfType<AudioManager>().Play("Water");
        }
    }
}
