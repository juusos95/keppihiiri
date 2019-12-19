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
    int hp = 2;
    Animator anim;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        frog = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("goBack", goBack);
        anim.SetBool("aggro", aggro);
        anim.SetBool("jump", grounded);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
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
            aggro = true;
        }
        else if (other.gameObject.tag == "goBack")
        {
            transform.position = new Vector3(transform.position.x + backSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            goBack = true;
        }
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
        {
            hp -= 1;
            frog.AddExplosionForce(6000, player.position, 5000);
            Debug.Log("aoiliholuigb");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}