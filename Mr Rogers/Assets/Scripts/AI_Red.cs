using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Red : AI_Person {

	void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if (timer > 1)
        {
            Decide();
            timer = 0f;
        }
        if (!grasped) //if not being handled, be free
        {
            transform.Rotate(Vector3.zero);
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (target) // if target, sit still and fire
            {
                body.velocity = Vector3.zero;
                animator.SetTrigger("fire");
            }
            else //otherwise, wander around
                body.velocity = speed * new Vector3(x, body.velocity.y, z);
            animator.SetBool("walk", (x != 0f) && (z != 0f));

        }
        else //otherwise, do nothing
            body.constraints = RigidbodyConstraints.None;
        animator.SetBool("grasped", grasped);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AI_Wolf>() && (target == null))
        {
            target = other.gameObject;
        }
    }
}
