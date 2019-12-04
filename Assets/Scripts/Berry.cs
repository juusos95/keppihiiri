using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    bool berryOn;
    public GameManager gamemanager;

    [SerializeField] Transform spearParent;
    private float destroy = 0.0f;
    private float push = 0.1f;
    public SphereCollider cc;
    public Rigidbody rb;
    FixedJoint fj;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Spear"&&collider.GetComponent<BoxCollider>() && !berryOn && gamemanager.poking)
        {
            cc.enabled = false;
            fj = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            rb = collider.gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
            fj.connectedBody = rb;
            fj.connectedMassScale = 0;
            berryOn = true;
        }
    }
    private void Update()
    {
        if (Input.GetKey("e") && GetComponent<FixedJoint>() && berryOn)            //Eat berry that is stuck on the spear
        {
            //HealthController.health += 20f;
            Destroy(gameObject);
        }
        else if (Input.GetMouseButtonDown(0) && GetComponent<FixedJoint>())  //Detach berry from spear
        {
            StartCoroutine(Kill());


           
        }

    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(destroy);

        cc.enabled = true;
        Destroy(GetComponent<FixedJoint>());


        transform.rotation = spearParent.rotation;
        berryOn = false;
        StartCoroutine(Push());
    }
    IEnumerator Push()
    {
        yield return new WaitForSeconds(push);
        rb.AddRelativeForce(Vector3.right * 5f);
        berryOn = false;
    }
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collider.transform.parent = null;
        }
    }*/
}
