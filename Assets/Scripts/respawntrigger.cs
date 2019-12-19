using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawntrigger : MonoBehaviour
{

    public Animator animator;
    public float deathdelay = 1f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.Play("Fadein");
            Invoke("Death", deathdelay);
        }
    }

    void Death()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
