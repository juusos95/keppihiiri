using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class spearTip : MonoBehaviour
{
    [SerializeField] Transform spearParent;

    void Update()
    {
        transform.rotation = spearParent.rotation;
    }
}
=======
public class spearTip : MonoBehaviour
{

    private float disablecollider = 0f;

    private float enablecollider = 0.5f;
    public BoxCollider bc;
    [SerializeField] Transform spearParent;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && other.gameObject.tag == "Berri")
        {
            Debug.Log("poke");
            bc.enabled = false;
            //StartCoroutine(DisableCollider());
            StartCoroutine(Enable());
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = spearParent.rotation;
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(disablecollider);


        Debug.Log("poke2");
    }
    IEnumerator Enable()
    {
        yield return new WaitForSeconds(enablecollider);
        bc.enabled = true;
        Debug.Log("poke3");
    }
}
>>>>>>> TuukkaBranch
