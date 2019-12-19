using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakSpot : MonoBehaviour
{
    public GameManager gm;
    public int hp = 6;

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Spear" && gm.poking)
        {
            GetComponentInParent<Rigidbody>().AddExplosionForce(5000, GameObject.FindGameObjectWithTag("Player").transform.position, 500);
            hp -= 1;
        }
    }
}
