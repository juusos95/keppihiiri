using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public bool berryOn;
    public GameManager gamemanager;

    [SerializeField] Transform spearParent;
    private float destroy = 0.0f;
    private float push = 0.1f;
    public SphereCollider cc;
    public Rigidbody rb;
    FixedJoint fj;
    Transform temp;
    public BoxCollider tip;

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
            Debug.Log("Berry is attached");
        }
    }
    private void Update()
    {
        if (Input.GetKey("e") && GetComponent<FixedJoint>() && berryOn)            //Eat berry that is stuck on the spear
        {
            HealthController.health += 20f;
            FindObjectOfType<AudioManager>().Play("Eat");
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
        Physics.IgnoreCollision(tip.GetComponent<BoxCollider>(), cc.GetComponent<SphereCollider>());
        //temp = gameObject.transform.parent;
        //gameObject.transform.parent = spearParent.transform;
        transform.rotation = spearParent.rotation;
        berryOn = false;
        StartCoroutine(Push());
        //gameObject.transform.parent = temp;
    }
    IEnumerator Push()
    {
        yield return new WaitForSeconds(push);
        
        rb.AddRelativeForce(Vector3.right * 50f, ForceMode.Force);
        //rb.velocity = Vector3.right * 15f;
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
