
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spearControl : MonoBehaviour
{
    Rigidbody rb;
    public float angle;
    ConfigurableJoint cj;
    public float anchorX;
    public float anchorY;
    int wallMask;
    float camRayLength = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cj = GetComponent<ConfigurableJoint>();
        wallMask = LayerMask.GetMask("wall");
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
        if (Physics.Raycast(camRay, out wallHit, camRayLength, wallMask))
        {
            Vector3 toMouse = wallHit.point - transform.position;
            toMouse.z = 0;
            anchorX = toMouse.x / 10;
            anchorX = Mathf.Clamp(anchorX, -0.75f, 0.75f);
            anchorY = toMouse.y / -10 * 1.5f;
            anchorY = Mathf.Clamp(anchorY, -0.15f, 0.9f);
            cj.connectedAnchor = new Vector3(anchorX, anchorY, 0);
            angle = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.MoveRotation(newRot);
        }
    }
}