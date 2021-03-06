﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    const int WANDER = 0, POINTED = 1, GRABBED = 2, TARGET = 3;


    public bool pointed = false;
    public bool grabbed = false;

    [SerializeField] protected float speed;
    protected float timer = 0f;
    protected Vector3 move = Vector3.zero;

    protected Rigidbody body;
    protected Animator animator;
    protected GameObject target;

    protected int state = WANDER;

    protected void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
	
	void FixedUpdate () {
        state = Decide();
        switch (state) {
            case WANDER:
                Wander();
                break;
            case POINTED:
                Pointed();
                break;
            case GRABBED:
                //body.constraints = RigidbodyConstraints.None;
                break;
            case TARGET:
                Target();
                break;
            default:
                break;
        }
        animator.SetBool("grasped", grabbed);
        animator.SetBool("walk", (move.x != 0f) && (move.z != 0f));
    }

    private int Decide()
    {
        if (grabbed)
            return GRABBED;
        if (target != null)
            return TARGET;
        if (pointed)
            return POINTED;
        return WANDER;
    }

    protected virtual void Wander()
    {
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        timer += Time.fixedDeltaTime;
        if (timer > 2f)
        {
            if ((move.x == 0f) || (move.z == 0f))
            {
                move.x = Random.Range(-1f, 1f);
                move.y = 0f;
                move.z = Random.Range(-1f, 1f);
                move *= speed;
                if (move.x < 0f)
                    animator.SetBool("left", true);
                else if (move.x > 0f)
                    animator.SetBool("left", false);
            }
            else
                move = Vector3.zero;
            timer = 0f;
        }
        move.y = body.velocity.y;
        body.velocity = move;
    }

    protected virtual void Pointed()
    {
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        move = Vector3.up * body.velocity.y;
        body.velocity = move;
    }

    protected virtual void Target()
    {
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        move = Vector3.up * body.velocity.y;
        body.velocity = move;
        animator.SetBool("left", target.transform.position.x < transform.position.x);
        if (timer > 1f)
        {
            animator.SetTrigger("fire");
            timer = 0f;
        }
    }

    public virtual void Attack()
    {

    }
}
