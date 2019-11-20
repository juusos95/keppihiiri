using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StickJab : MonoBehaviour
{
    public Transform player;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Jab");
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            collider.transform.parent = null;
        }*/
    }

    IEnumerator Jab()
    {
        transform.localPosition = new Vector3(0, 0, 5);
        yield return new WaitForSeconds(.3f);
        transform.localPosition = new Vector3(0, 0, 2);
    }
}
