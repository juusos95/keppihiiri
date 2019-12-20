
﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    bool gameHasEnded = false;

    public bool poking;

    public float restartDelay = 1f;

    public float finishDelay = 1f;

    public GameObject finishMenuUI;

    public Animator animator;

    public Animator animator2;

    public Animator animator3;

    public Animator animator4;

    public void CompleteLevel()
    {
        finishMenuUI.SetActive(true);
        Debug.Log("You're Winner!... olet viineri...");
        Invoke("Finish", finishDelay);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Shindeiru");
            Invoke("Restart", restartDelay);

            animator.Play("Fadein");

            animator2.Play("off");

            animator3.Play("off");

            animator4.Play("off");
        }
    }

    public void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Finish()
    {
        Time.timeScale = 0f;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void poke()
    {
        if (!poking)
        {
            poking = true;
        }
        else if (poking)
        {
            poking = false;
        }
    }
}
