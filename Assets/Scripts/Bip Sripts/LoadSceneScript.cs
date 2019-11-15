using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    [SerializeField] private bool loadSceneByName = false;
    [SerializeField] private int levelToLoad = 0;

    public void LoadScene()
    {
        if (!loadSceneByName)
        {
            SceneManager.LoadScene(levelToLoad);
            Time.timeScale = 1f;
        }
    }
}
