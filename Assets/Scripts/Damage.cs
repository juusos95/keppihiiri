﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter (Collider col)
    {
        HealthController.health -= 20f;
    }
}
