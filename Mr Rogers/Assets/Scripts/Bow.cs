using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    [SerializeField]AI_Hero hero;

    private void Start()
    {
        hero = GetComponentInParent<AI_Hero>();
    }

    public void Attack()
    {
        hero.Attack();
    }
}
