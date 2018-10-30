using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Person : MonoBehaviour {
    public bool grasped
    {
        get
        {
            return _grasped;
        }
        set
        {
            _grasped = value;
        }
    }

    public bool pointed
    {
        get
        {
            return _pointed;
        }
        set
        {
            _pointed = value;
        }
    }

    private bool _pointed = false;
    private bool _grasped = false;
    [SerializeField] float speed;
    float x = 0f, z = 0f, timer = 0f;
    Rigidbody body;
    Animator animator;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Start () {
		
	}
	
	void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if (timer > 1)
        {
            Decide();
            timer = 0f;
        }
        if (!grasped)
        {
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            body.velocity = speed * new Vector3(x, body.velocity.y, z);
        }
        else
        {
            body.constraints = RigidbodyConstraints.None;
            transform.Rotate(0f, transform.rotation.y, 0f);
        }
        animator.SetBool("grasped", grasped);
        animator.SetBool("walk", (x != 0f) && (z != 0f));
    }

    void Decide()
    {
        if (!grasped)
        {
            Debug.Log("Decide");
            x = Random.Range(-1f, 1f);
            z = Random.Range(-1f, 1f);
        }
    }
}
