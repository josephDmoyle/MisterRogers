using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Person : MonoBehaviour {
    public bool grasped = false;
    [SerializeField] float speed;
    float x, z;
    Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        Invoke("Decide", 1);
    }
    void Start () {
		
	}
	
	void FixedUpdate () {
        if (!grasped)
        {
            body.velocity = speed * new Vector3(x, 0, z);
        }
    }

    void Decide()
    {
        Invoke("Decide", 1);
        if (!grasped)
        {
            Debug.Log("Decide");
            body.velocity = Vector3.zero;
            x = Random.Range(-1f, 1f);
            z = Random.Range(-1f, 1f);
        }
    }
}
