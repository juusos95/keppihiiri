using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Vesi" && collider.GetComponent<BoxCollider>())
        {
            FindObjectOfType<AudioManager>().Play("Water");
        }
    }
}
