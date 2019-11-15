using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearControl : MonoBehaviour
{
    Vector3 mousePos;
    float camRayLength = 100;
    int wallMask;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        wallMask = LayerMask.GetMask("invisibleWall");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateSpear();
    }

    void rotateSpear()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit wallHit;

        if(Physics.Raycast(camRay, out wallHit, camRayLength, wallMask))
        {
            Vector3 toMouse = wallHit.point - transform.position;

            toMouse.z = 0;

            Quaternion newRot = Quaternion.LookRotation(toMouse);

            rb.MoveRotation(newRot);
        }
    }
}
