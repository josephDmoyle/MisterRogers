using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Wolf: AI_Person {

    void Start () {
		
	}
	
	void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if (target == null)
        {
            if (timer > 1)
            {
                Decide();
                timer = 0f;
            }
            body.velocity = speed * new Vector3(x, body.velocity.y, z);
        }
        else
        {
            Vector3 look = target.transform.position - transform.position;
            body.velocity = speed * new Vector3(look.x, body.velocity.y, look.z);
        }
        animator.SetBool("walk", (x != 0f) && (z != 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AI_Person>())
        {
            target = other.gameObject;
        }
    }
}
