using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maali : MonoBehaviour
{

    public Animator animator;
    [SerializeField] private bool loadSceneByName = false;
    [SerializeField] private int levelToLoad = 0;
    public float finishDelay = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (!loadSceneByName && other.gameObject.tag == "MaaliCheck")
        {
            Time.timeScale = 1f;
            animator.Play("Fadein");
            Invoke("Finish", finishDelay);
        }
    }

    void Finish()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
