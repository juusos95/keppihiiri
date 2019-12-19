using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Player" && collider.GetComponent<CapsuleCollider>())
        {
            HealthController.health -= 20f;
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
        }
    }
}
