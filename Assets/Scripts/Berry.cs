using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Berry : MonoBehaviour
{
    public bool berryOn;
    public GameManager gm;
    public Transform spearParent;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && berryOn)
        {
            detachBerry();
        }
        else if (Input.GetKey("e") && berryOn)
        {
            HealthController.health += 20f;
            FindObjectOfType<AudioManager>().Play("Eat");
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
    }
    private void detachBerry()
    {
        berryOn = false;
        transform.rotation = spearParent.rotation;
        Destroy(GetComponent<FixedJoint>());
        rb.constraints = RigidbodyConstraints.None;
        rb.AddExplosionForce(500, spearParent.position, 500);
    }
}
