using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class frogController : MonoBehaviour
{
    public Transform player;
    float speed = 5;
    float backSpeed = 3.5f;
    Rigidbody frog;
    Vector3 jumpForce;
    bool aggro;
    bool goBack;
    bool grounded;
<<<<<<< HEAD

    int hp = 2;

    Animator anim;

    public GameManager gm;

=======
    public int hp = 6;
    Animator anim;
    public GameManager gm;
>>>>>>> master
    // Start is called before the first frame update
    void Start()
    {
        frog = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
<<<<<<< HEAD

=======
>>>>>>> master
    private void Update()
    {
        anim.SetBool("goBack", goBack);
        anim.SetBool("aggro", aggro);
        anim.SetBool("jump", grounded);
<<<<<<< HEAD

=======
>>>>>>> master
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
<<<<<<< HEAD

        if (transform.position.x < player.position.x)
        {
            backSpeed = -2;
            jumpForce = new Vector3(5000, 4000, 0);
=======
        if (transform.position.x < player.position.x)
        {
            backSpeed = -2;
            jumpForce = new Vector3(500, 400, 0);
>>>>>>> master
        }
        else if (transform.position.x > player.position.x)
        {
            backSpeed = 2;
<<<<<<< HEAD
            jumpForce = new Vector3(-5000, 4000, 0);
=======
            jumpForce = new Vector3(-500, 400, 0);
>>>>>>> master
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "aggroCheck")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            aggro = true;
        }
        else if (other.gameObject.tag == "goBack")
        {
            transform.position = new Vector3(transform.position.x + backSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            goBack = true;
        }
<<<<<<< HEAD
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck")
        {
            frog.AddForce(jumpForce);
        }
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (other.gameObject.tag == "Spear" && gm.poking)
=======

        if (other.gameObject.tag == "Spear" && gm.poking)
        {
            hp -= 1;
            frog.AddExplosionForce(200, player.position, 500 / 3);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumpCheck")
        {
            frog.AddForce(jumpForce);
        }
        if (other.gameObject.tag == "ground")
>>>>>>> master
        {
            hp -= 1;
            frog.AddExplosionForce(6000, player.position, 5000);
            Debug.Log("aoiliholuigb");
        }
    }
<<<<<<< HEAD

=======
>>>>>>> master
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}