using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickJab : MonoBehaviour
{
    public Transform player;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localPosition = new Vector3(player.position.x, player.position.y, player.position.z + 15);

        }

        /*if (Input.GetMouseButtonDown(0))
        {
            collider.transform.parent = null;
        }*/
    }
}
