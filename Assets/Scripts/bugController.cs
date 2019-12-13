using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugController : MonoBehaviour
{
    public bool aggro;
    public bool attacking;
    public bool grounded;
    Rigidbody rb;
    Collider collider;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        else if (!grounded)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck" && !attacking && player.transform.position.x < transform.position.x)
        {
            aggro = true;
            StartCoroutine(prepare(-75, 2.25f));
        }
        else if (other.gameObject.tag == "aggroCheck" && !attacking && player.transform.position.x > transform.position.x)
        {
            aggro = true;
            StartCoroutine(prepare(75, 2.25f));
        }
        else if (other.gameObject.tag == "jumpCheck" && !attacking && player.transform.position.x < transform.position.x)
        {
            aggro = true;
            StartCoroutine(prepare(-75, 2f));
        }
        else if (other.gameObject.tag == "jumpCheck" && !attacking && player.transform.position.x > transform.position.x)
        {
            aggro = true;
            StartCoroutine(prepare(75, 2f));
        }
        else if (other.gameObject.tag == "goBack" && !attacking && player.transform.position.x < transform.position.x)
        {
            aggro = true;
            StartCoroutine(prepare(-75, 1.75f));
        }
        else if (other.gameObject.tag == "goBack" && !attacking && player.transform.position.x > transform.position.x)
        {
            aggro = true;
            StartCoroutine(prepare(75, 1.75f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck")
        {
            aggro = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
    IEnumerator prepare(float charge, float time)
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(attack(charge, time));
    }

    IEnumerator attack(float charge, float time)
    {
        attacking = true;
        float currentX = transform.localPosition.x;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            rb.AddForce(charge, 0, 0);
            yield return null;
        }
        StartCoroutine(stop());
    }

    /*IEnumerator attack(float charge, float time)
    {
        yield return new WaitForSeconds(time);
        rb.AddForce(Vector3.right * charge);

        StartCoroutine(stop());
    }*/

    IEnumerator stop()
    {
        rb.velocity = new Vector3(0, rb.velocity.y);
        yield return new WaitForSeconds(1.5f);
        collider.enabled = false;
        attacking = false;
        collider.enabled = true;
    }
}
