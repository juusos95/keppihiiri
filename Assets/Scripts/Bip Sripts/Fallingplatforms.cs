using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatforms : MonoBehaviour
{
    public float fallDelay = 2.0f;

    public float Respawn = 2.0f;
    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2;

    public Animator animator;

    public Rigidbody2D rbd;
    
    public Vector2 initialposition;

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Respawn);
        rbd.isKinematic = true;
        boxCol.enabled = true;
        boxCol2.enabled = true;
        transform.position = initialposition;
        rbd.velocity = Vector2.zero;
        animator.Play("Platformspawn");
    }

    private void Start()
    {
        initialposition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collidedWithThis)
    {
        if (collidedWithThis.gameObject.tag == "Player")
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        rbd.isKinematic = false;
        boxCol.enabled = false;
        boxCol2.enabled = false;
        StartCoroutine(Spawn());

        animator.Play("Platformrest");
    }
}

