using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    Rigidbody rb;
    FixedJoint fj;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Berri"&&collider.GetComponent<BoxCollider>())
        {
            fj = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            rb = collider.gameObject.GetComponentInChildren(typeof(Rigidbody)) as Rigidbody;
            fj.connectedBody = rb;
            fj.connectedMassScale = 0;
        }
    }
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collider.transform.parent = null;
        }
    }*/
}
