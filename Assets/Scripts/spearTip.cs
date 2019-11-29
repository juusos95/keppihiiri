using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearTip : MonoBehaviour
{
    [SerializeField] Transform spearParent;

    void Update()
    {
        transform.rotation = spearParent.rotation;
    }
}
