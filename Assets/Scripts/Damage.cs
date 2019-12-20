using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter (Collision collider)
    {
        if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<CapsuleCollider>())
        {
            HealthController.health -= 20f;
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            collider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 500);
        }
    }
}
