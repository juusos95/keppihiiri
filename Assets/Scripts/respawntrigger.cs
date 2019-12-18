using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawntrigger : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    
}
