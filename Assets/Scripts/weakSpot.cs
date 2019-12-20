
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
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
            Debug.Log("guvbvauijf");
            FindObjectOfType<AudioManager>().Play("Bug");
            GetComponentInParent<Rigidbody>().AddExplosionForce(5000, GameObject.FindGameObjectWithTag("Player").transform.position, 500);
            hp -= 1;
        }
    }
}
