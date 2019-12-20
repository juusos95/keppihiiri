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
    public bool grounded;
    public int hp = 6;
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
            jumpForce = new Vector3(500, 400, 0);
        }
        else if (transform.position.x > player.position.x)
        {
            backSpeed = 2;
            jumpForce = new Vector3(-500, 400, 0);
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
        if (other.gameObject.tag == "Spear" && gm.poking)
        {
            FindObjectOfType<AudioManager>().Play("Frog");
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
        {
            grounded = true;
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