using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject creditsButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject backButton;

    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;

    public float startDelay = 1f;

    public void PlayGame()
    {
        Invoke("Startup", startDelay);
        animator.Play("Fadein");
        animator2.Play("off");
        animator3.Play("off");
        animator4.Play("off");

    }

    void Startup()
    {
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(+1);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Credits()
    {
        Debug.Log("F");
        playButton.transform.localPosition = new Vector3(10000, 0, 0);
        creditsButton.transform.localPosition = new Vector3(10000, 0, 0);
        quitButton.transform.localPosition = new Vector3(10000, 0, 0);
        backButton.transform.localPosition = new Vector3(378, -29, 0);
    }
    
    public void Back()
    {
        playButton.transform.localPosition = new Vector3(16.04f, 130, 0);
        creditsButton.transform.localPosition = new Vector3(16.04f, -10, 0);
        quitButton.transform.localPosition = new Vector3(16.04f, -150, 0);
        backButton.transform.localPosition = new Vector3(10000, 0, 0);
    }
}
