using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearControl : MonoBehaviour
{
    Rigidbody rb;
    public float angle;
    ConfigurableJoint cj;
    float anchorX;
    float anchorY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cj = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateSpear();

        transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
    }

    void rotateSpear()
    {
        Vector3 toMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition - transform.position);

        toMouse.z = 0;

        anchorX = (toMouse.x - transform.position.x) / 10;
        anchorX = Mathf.Clamp(anchorX, -0.75f, 0.75f);

        anchorY = (toMouse.y - transform.position.y) / -10 * 2.5f;
        anchorY = Mathf.Clamp(anchorY, -0.1f, 0.9f);

        cj.connectedAnchor = new Vector3(anchorX, anchorY, 0);

        angle = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
        Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward);

        rb.MoveRotation(newRot);
    }
}
