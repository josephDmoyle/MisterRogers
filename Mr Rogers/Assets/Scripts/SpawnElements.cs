using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElements : MonoBehaviour {

    
    [SerializeField]
    private GameObject ObjectToSpawn;
    [SerializeField]
    private float delay;
    private float totalSpawner = 4;
    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = delay;
    }

    // Update is called once per frame
    void Update () {
        if(shouldSpawn())
        {
            Spawn();
        }		
	}

    private void Spawn()
    {
        nextSpawnTime = Time.time + 20;
        Instantiate(ObjectToSpawn, transform.position, transform.rotation);
    }

    private bool shouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }
}
