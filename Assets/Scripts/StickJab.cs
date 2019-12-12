using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StickJab : MonoBehaviour
{
<<<<<<< HEAD
    public GameManager gamemanager;
    GameManager gm;
    bool poking;

    private void Update()
    {
        poking = gamemanager.poking;

=======
    public bool poking;
    public Rigidbody rb;
    public GameManager gamemanager;
    public float jumpForce;
    BoxCollider bc;
    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }
    private void Update()
    {
>>>>>>> master
        if (Input.GetMouseButtonDown(0) && !poking)
        {
            StartCoroutine(poke(1.0f, 0.1f));
            poking = true;
<<<<<<< HEAD
            StartCoroutine(poke(2.0f, 0.08f));
            gamemanager.poke();
            FindObjectOfType<AudioManager>().Play("StickJab");

            /*while (transform.localPosition.x < 1)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 1 * Time.deltaTime, 0, 0);
            }*/
=======
            gamemanager.poke();
>>>>>>> master
        }
    }
    IEnumerator poke(float distance, float time)
    {
        float currentX = transform.localPosition.x;
<<<<<<< HEAD

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            transform.localPosition = new Vector3(Mathf.Lerp(currentX, distance, t), 0, 0);
=======
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            transform.localPosition = new Vector3(Mathf.Lerp(currentX, distance * 1.2f, t), 0, 0);
            bc.size = new Vector3(Mathf.Lerp(currentX, distance, t), 0.4f, 0.4f);
            bc.center = new Vector3(Mathf.Lerp(currentX, distance, t), 0, 0);
>>>>>>> master
            yield return null;
        }
        if (poking)
        {
            gamemanager.poke();
<<<<<<< HEAD
            StartCoroutine(poke(0.0f, 0.2f));
        }
    }

=======
            poking = false;
            StartCoroutine(poke(0.0f, 0.2f));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground" && poking)
        {
            rb.AddRelativeForce(Vector3.right * -jumpForce, ForceMode.VelocityChange);
            Debug.Log("test");
        }
    }
>>>>>>> master
    /*IEnumerator Jab()
    {
        transform.localPosition = new Vector3(1, 0, 0);
        yield return new WaitForSeconds(.3f);
        transform.localPosition = new Vector3(0, 0, 0);
    }*/
}