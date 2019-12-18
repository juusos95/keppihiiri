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
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        anim.SetBool("goBack", goBack);
        anim.SetBool("aggro", aggro);
        anim.SetBool("jump", grounded);
        /*if (player.position.x < transform.position.x - 15 || player.position.x > transform.position.x + 15)
        {
            Debug.Log("hei");
        }*/
        if (aggro && player.position.x < transform.position.x && !goBack && grounded)
        {
            transform.position = new Vector3(transform.position.x + 2f * -Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (aggro && player.position.x > transform.position.x && !goBack && grounded)
        {
            transform.position = new Vector3(transform.position.x + 2f * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(1, 1, -1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck" && player.position.x < transform.position.x)
        {
            rb.AddForce(new Vector3(0, 400, 0));
        }

        else if (other.gameObject.tag == "jumpCheck" && player.position.x > transform.position.x)
        {
            rb.AddForce(new Vector3(0, 400, 0));
        }

        else if (other.gameObject.tag == "aggroCheck")
        {
            aggro = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "goBack" && player.position.x < transform.position.x && grounded)
        {
            transform.position = new Vector3(transform.position.x + 1.5f * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(1, 1, 1);
            goBack = true;
        }
        else if (other.gameObject.tag == "goBack" && player.position.x > transform.position.x && grounded)
        {
            transform.position = new Vector3(transform.position.x + -1.5f * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(1, 1, -1);
            goBack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck" && !grounded && player.position.x < transform.position.x)
        {
            rb.velocity = new Vector3(-10, rb.velocity.y, 0);
        }
        else if (other.gameObject.tag == "jumpCheck" && !grounded && player.position.x > transform.position.x)
        {
            rb.velocity = new Vector3(10, rb.velocity.y, 0);
        }

        if (other.gameObject.tag == "aggroCheck")
        {
            aggro = false;
        }
        if (other.gameObject.tag == "goBack")
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
