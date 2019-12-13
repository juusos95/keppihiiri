using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugController : MonoBehaviour
{
    public bool aggro;
    public bool attacking;
    Rigidbody rb;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro && player.position.x < transform.position.x && !attacking)
        {
            StartCoroutine(attack(-10, 1));
        }
        else if (aggro && player.position.x > transform.position.x && !attacking)
        {
            StartCoroutine(attack(10, 1));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck")
        {
            aggro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck")
        {
            aggro = false;
        }
    }

    IEnumerator attack(float charge, float time)
    {
        yield return new WaitForSeconds(time);
        rb.AddForce(Vector3.right * charge);

        StartCoroutine(stop());
    }

    IEnumerator stop()
    {
        attacking = true;
        yield return new WaitForSeconds(3);
        rb.velocity = new Vector3(0, rb.velocity.y);
        attacking = false;
    }
}
