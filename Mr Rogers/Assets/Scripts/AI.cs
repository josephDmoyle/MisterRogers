using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    const int WANDER = 0, GRABBED = 1, TARGET = 2;

    public bool grabbed = false;

    [SerializeField] protected float speed;
    protected float timer = 0f;
    protected Vector3 move = Vector3.zero;

    protected Rigidbody body;
    protected Animator animator;
    protected Collider colider;
    [SerializeField]protected GameObject target;

    protected int state = WANDER;

    protected void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        colider = GetComponent<Collider>();
    }

    protected virtual void Start()
    {
        Index.index.VillagerNew(this);
    }

    protected virtual void OnDestroy()
    {
        Index.index.VillagerDie(this);
    }

    void FixedUpdate () {
        state = Decide();
        switch (state) {
            case WANDER:
                Wander();
                break;
            case GRABBED:
                Grabbed();
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
        Scan();
        if (grabbed)
            return GRABBED;
        if (target != null)
            return TARGET;
        return WANDER;
    }

    protected virtual void Wander()
    {
        timer += Time.fixedDeltaTime;
        if (timer > 2f)
        {
            if ((move.x == 0f) || (move.z == 0f))
            {
                move.x = Random.Range(-1f, 1f);
                move.y = 0f;
                move.z = Random.Range(-1f, 1f);
                if ((move.x != 0f) || (move.z != 0f))
                    move.Normalize();
                move *= speed;
                if (move.x <= 0f)
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

    protected virtual void Grabbed()
    {
        move.x = 0f;
        move.z = 0f;
    }
    protected virtual void Target()
    {
        move = Vector3.zero;
        move.y = body.velocity.y;
        body.velocity = move;
        animator.SetBool("left", target.transform.position.x < transform.position.x);
        if (timer > 2f)
        {
            animator.SetTrigger("fire");
            timer = 0f;
        }
    }

    protected virtual void Scan()
    {

    }

    public virtual void Attack()
    {

    }
}
