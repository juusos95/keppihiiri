using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearControl : MonoBehaviour
{
    Vector3 mousePos;
    float camRayLength = 100;
    int wallMask;
    Rigidbody rb;

    Vector3 m_EulerAngleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        wallMask = LayerMask.GetMask("invisibleWall");
        rb = GetComponent<Rigidbody>();

        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateSpear();

        transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
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

            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);

            //rb.MoveRotation(newRot * deltaRotation);

            transform.rotation = new Quaternion(0, 0, newRot * deltaRotation);
        }
    }
}
