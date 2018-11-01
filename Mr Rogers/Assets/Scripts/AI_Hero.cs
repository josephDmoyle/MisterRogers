using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Hero : AI {

    protected override void Start()
    {
        Index.index.HeroNew(this);
    }

    protected override void OnDestroy()
    {
        Index.index.HeroDie(this);
    }

    protected override void Scan()
    {
        if (Index.index.wolves.Count > 0)
        {
            float min = float.MaxValue;
            foreach (AI wolf in Index.index.wolves)
            {
                if (Vector3.Distance(transform.position, wolf.transform.position) < min)
                {
                    min = Vector3.Distance(transform.position, wolf.transform.position);
                    target = wolf.gameObject;
                }
            }
        }
        else
            target = null;
    }

    public override void Attack()
    {
        
    }
}
