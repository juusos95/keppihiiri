using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froggo : MonoBehaviour
{
    public Transform player;
    float speed = 5;
    float backSpeed = 2.5f;
    Rigidbody frog;
    Vector3 jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        frog = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.x < player.position.x)
        {
            backSpeed = -2;
            jumpForce = new Vector3(5000, 4000, 0);
        }
        else if (transform.position.x > player.position.x)
        {
            backSpeed = 2;
            jumpForce = new Vector3(-5000, 4000, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(other.gameObject.tag == "goBack")
        {
            transform.position = new Vector3(transform.position.x + backSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck")
        {
            frog.AddForce(jumpForce);
            Debug.Log("iohjefkdsgt");
        }
    }
}
