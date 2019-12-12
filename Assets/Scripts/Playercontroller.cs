using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    private float moveInput;

    private Rigidbody rb;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("speed", rb.velocity.x);
        moveInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
    }
}
