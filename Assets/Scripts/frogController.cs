using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogController : MonoBehaviour
{
    public bool aggro;
    public bool grounded;
    public bool goBack;
    Rigidbody rb;
    [SerializeField] Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        /*if (player.position.x < transform.position.x - 15 || player.position.x > transform.position.x + 15)
        {
            Debug.Log("hei");
        }*/
        if (aggro && player.position.x < transform.position.x && !goBack)
        {
            transform.position = new Vector3(transform.position.x + 1.5f * -Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (aggro && player.position.x > transform.position.x && !goBack)
        {
            transform.position = new Vector3(transform.position.x + 1.5f * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck" && player.position.x < transform.position.x)
        {
            rb.AddForce(new Vector3(-500, 1000, 0));
        }

        else if (other.gameObject.tag == "jumpCheck" && player.position.x > transform.position.x)
        {
            rb.AddForce(new Vector3(500, 1000, 0));
        }
        else if (other.gameObject.tag == "aggroCheck")
        {
            aggro = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck" && player.position.x < transform.position.x && grounded)
        {
            transform.position = new Vector3(transform.position.x + 1.5f * Time.deltaTime, transform.position.y, transform.position.z);
            goBack = true;
        }
        else if (other.gameObject.tag == "jumpCheck" && player.position.x > transform.position.x && grounded)
        {
            transform.position = new Vector3(transform.position.x + -1.5f * Time.deltaTime, transform.position.y, transform.position.z);
            goBack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck")
        {
            aggro = false;
        }
        if (other.gameObject.tag == "jumpCheck")
        {
            goBack = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = false;
        }
    }
}
