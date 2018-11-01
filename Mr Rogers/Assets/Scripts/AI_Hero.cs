using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Hero : AI {

    [SerializeField]GameObject arrow;
    [SerializeField] Transform crosshair;
    [SerializeField] float range;

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
            float min = range;
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
        if (target)
        {
            Vector3 bow = (target.transform.position - crosshair.position);
            bow.y = crosshair.position.y;
            bow.Normalize();
            GameObject fly = Instantiate(arrow, crosshair.position + bow, Quaternion.identity);
            fly.transform.right = bow;
            fly.GetComponent<Rigidbody>().velocity = bow * 8;
        }
    }
}
