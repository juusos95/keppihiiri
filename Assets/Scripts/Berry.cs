using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Berry : MonoBehaviour
{
    public bool berryOn;
<<<<<<< HEAD
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
        if (collider.gameObject.tag == "Spear" && collider.GetComponent<BoxCollider>() && !berryOn && gamemanager.poking)
        {
            cc.enabled = false;
            fj = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            rb = collider.gameObject.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
            fj.connectedBody = rb;
            fj.connectedMassScale = 0;
            berryOn = true;
            Debug.Log("Berry is attached");
        }
=======
    public GameManager gm;
    public Transform spearParent;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
>>>>>>> master
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && berryOn)
        {
            detachBerry();
        }
        else if (Input.GetKey("e") && berryOn)
        {
<<<<<<< HEAD
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
=======
            HealthController.health += 20f;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spear" && gm.poking && !berryOn)
        {
            berryOn = true;
            FixedJoint fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            fj.connectedMassScale = 0;
        }
>>>>>>> master
    }
    private void detachBerry()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(push);
        rb.AddRelativeForce(Vector3.right * 50f, ForceMode.Force);
        //rb.velocity = Vector3.right * 15f;
=======
>>>>>>> master
        berryOn = false;
        transform.rotation = spearParent.rotation;
        Destroy(GetComponent<FixedJoint>());
        rb.AddRelativeForce(7, 0, 0, ForceMode.VelocityChange);
    }
<<<<<<< HEAD
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collider.transform.parent = null;
        }
    }*/
=======
>>>>>>> master
}