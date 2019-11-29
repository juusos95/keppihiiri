using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogHealth : MonoBehaviour
{
    public int health = 2;
    [SerializeField] GameObject frog;

    void Update()
    {
        if (health == 0)
        {
            Destroy(frog);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spear")
        {
            health = health - 1;
        }
    }
}
