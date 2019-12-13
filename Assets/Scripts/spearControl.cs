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
    public float spearZ;
    public Animator anim;
    public GameObject player;

    int wallMask;
    float camRayLength = 100;
    public Vector3 toMouse;

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

        transform.position = new Vector3(transform.position.x, transform.position.y, spearZ);

        /*if (angle < 90 && angle > -90)
        {
            anim.SetBool("isRight", true);
            Vector3 Scaler = transform.localScale;
            Scaler.x = 1;
            player.transform.localScale = Scaler;

        }
        else
        {
            anim.SetBool("isRight", false);
            Vector3 Scaler = transform.localScale;
            Scaler.x = -1;
            player.transform.localScale = Scaler;
        }*/
    }

    void rotateSpear()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit wallHit;

        if (Physics.Raycast(camRay, out wallHit, camRayLength, wallMask))
        {
            toMouse = wallHit.point - transform.position;
            toMouse.z = 0;

            anchorX = toMouse.x / 10; //(toMouse.x - transform.position.x) / 10;
            anchorX = Mathf.Clamp(anchorX, -0.75f, 0.75f);

            anchorY = toMouse.y / -10 * 2; //(toMouse.y - transform.position.y) / -10 * 1.5f;
            anchorY = Mathf.Clamp(anchorY, -0.15f, 0.9f);

            cj.connectedAnchor = new Vector3(anchorX, anchorY, 0);

            angle = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward);

            rb.MoveRotation(newRot);
        }
    }
}
