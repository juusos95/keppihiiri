using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    Rigidbody rb;
    FixedJoint fj;
    public SphereCollider cc;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Spear"&&collider.GetComponent<BoxCollider>())
        {
            cc.enabled = false;
            fj = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            rb = collider.gameObject.GetComponentInChildren(typeof(Rigidbody)) as Rigidbody;
            fj.connectedBody = rb;
            fj.connectedMassScale = 0;
        }
    }
    private void Update()
    {
        if (Input.GetKey("e") && GetComponent<FixedJoint>())            //Eat berry that is stuck on the spear
        {
            //HealthController.health += 20f;
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(0) && GetComponent<FixedJoint>())  //Detach berry from spear
        {
            cc.enabled = true;
            Destroy(GetComponent<FixedJoint>());
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
