using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image healthBar;
    float maxHealth = 100f;
    public static float health;
    public GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame

    public void Update ()
    {
        healthBar.fillAmount = health / maxHealth;
        if (health == 0f)
        {
            gamemanager.EndGame();
        }
    }
}