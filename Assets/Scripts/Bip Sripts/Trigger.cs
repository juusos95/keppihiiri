using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Animator animator;
    void OnTriggerStay2D(Collider2D collisionInfo2D)
    {
        if (collisionInfo2D.tag == "Player")
        {

            animator.SetBool("Enter", true);

        }
      
    }

    private void OnTriggerExit2D(Collider2D collisionInfo2D)
    {

        if (collisionInfo2D.tag == "Player")
        {

            animator.SetBool("Enter", false);

        }
    }

}