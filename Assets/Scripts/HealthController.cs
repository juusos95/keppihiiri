using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = startHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        healthBar.fillAmount = health / startHealth;
    }
}
