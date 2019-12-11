using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StickJab : MonoBehaviour
{
    public GameManager gamemanager;
    GameManager gm;
    bool poking;

    private void Update()
    {
        poking = gamemanager.poking;

        if (Input.GetMouseButtonDown(0) && !poking)
        {
            StartCoroutine(poke(1.0f, 0.1f));
            poking = true;
            StartCoroutine(poke(2.0f, 0.08f));
            gamemanager.poke();
            FindObjectOfType<AudioManager>().Play("StickJab");

            /*while (transform.localPosition.x < 1)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 1 * Time.deltaTime, 0, 0);
            }*/
        }
    }
    IEnumerator poke(float distance, float time)
    {
        float currentX = transform.localPosition.x;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            transform.localPosition = new Vector3(Mathf.Lerp(currentX, distance, t), 0, 0);
            yield return null;
        }
        if (poking)
        {
            gamemanager.poke();
            StartCoroutine(poke(0.0f, 0.2f));
        }
    }

    /*IEnumerator Jab()
    {
        transform.localPosition = new Vector3(1, 0, 0);
        yield return new WaitForSeconds(.3f);
        transform.localPosition = new Vector3(0, 0, 0);
    }*/
}