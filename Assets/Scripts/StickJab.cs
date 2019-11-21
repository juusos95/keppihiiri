using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StickJab : MonoBehaviour
{
    float _lastUpdateTime;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float joku = 1 * Time.deltaTime;

            if (Time.time - _lastUpdateTime >= 1.0f)
            {
                _lastUpdateTime = Time.time;
                transform.localPosition = new Vector3(transform.localPosition.x + joku, 0, 0);
            }

            /*while (transform.localPosition.x < 1)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 1 * Time.deltaTime, 0, 0);
            }*/
        }
    }
    /*IEnumerator Jab()
    {
        transform.localPosition = new Vector3(1, 0, 0);
        yield return new WaitForSeconds(.3f);
        transform.localPosition = new Vector3(0, 0, 0);
    }*/
}