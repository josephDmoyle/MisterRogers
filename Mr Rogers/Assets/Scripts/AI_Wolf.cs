﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Wolf : AI {

    protected override void Start()
    {
        Index.index.WolfNew(this);
    }

    protected override void OnDestroy()
    {
        Index.index.WolfDie(this);
    }

    protected override void Scan()
    {
        if (Index.index.villagers.Count > 0)
        {
            float min = float.MaxValue;
            foreach (AI villager in Index.index.villagers)
            {
                if (Vector3.Distance(transform.position, villager.transform.position) < min)
                {
                    min = Vector3.Distance(transform.position, villager.transform.position);
                    target = villager.gameObject;
                }
            }
        }
        else
            target = null;
    }

    protected override void Target()
    {
        move = target.transform.position - transform.position;
        move.y = 0f;
        move.Normalize();
        move *= speed;
        move.y = body.velocity.y;
        body.velocity = move;
        animator.SetBool("left", target.transform.position.x < transform.position.x);
        if ((Vector3.Distance(target.transform.position, transform.position) < 1) && (timer == 2f))
        {
            animator.SetTrigger("fire");
            timer = 0f;
        }
    }

    public override void Attack()
    {
        
    }
}
