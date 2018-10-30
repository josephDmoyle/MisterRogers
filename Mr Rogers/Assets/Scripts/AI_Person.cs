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

    protected bool _pointed = false;
    protected bool _grasped = false;
    [SerializeField] protected float speed;
    protected float x = 0f, z = 0f, timer = 0f;
    protected Rigidbody body;
    protected Animator animator;
    protected GameObject target;

    protected void Awake()
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
            transform.Rotate(Vector3.zero);
            animator.SetBool("walk", (x != 0f) && (z != 0f));
        }
        else
        {
            body.constraints = RigidbodyConstraints.None;
        }
        animator.SetBool("grasped", grasped);
    }

    protected void Decide()
    {
        Debug.Log("Decide");
        x = Random.Range(-1f, 1f);
        z = Random.Range(-1f, 1f);
    }
}
