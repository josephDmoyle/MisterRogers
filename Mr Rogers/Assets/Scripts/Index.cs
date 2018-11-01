using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Index : MonoBehaviour {

    public List<AI> villagers = new List<AI>();
    public List<AI_Wolf> wolves = new List<AI_Wolf>();
    public List<AI_Hero> heros = new List<AI_Hero>();

    public static Index index;

    private void Awake()
    {
        if (index == null)
            index = this;
    }

    public void VillagerNew(AI i_villager)
    {
        villagers.Add(i_villager);
    }

    public void VillagerDie(AI i_villager)
    {
        villagers.Remove(i_villager);
    }

    public void WolfNew(AI_Wolf wolf)
    {
        wolves.Add(wolf);
    }

    public void WolfDie(AI_Wolf wolf)
    {
        wolves.Remove(wolf);
    }

    public void HeroNew(AI_Hero hero)
    {
        heros.Add(hero);
    }

    public void HeroDie(AI_Hero hero)
    {
        heros.Remove(hero);
    }
}
