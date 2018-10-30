using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Wolf: MonoBehaviour {

    [SerializeField] float speed;
    float x = 0f, z = 0f, timer = 0f;
    Rigidbody body;
    Animator animator;
    GameObject target;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
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

    void Decide()
    {
        Debug.Log("Decide");
        x = Random.Range(-1f, 1f);
        z = Random.Range(-1f, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AI_Person>())
        {
            target = other.gameObject;
        }
    }
}
