using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Person : MonoBehaviour {
    public bool grasped = false;
    [SerializeField] float speed;
    Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        Invoke("Decide", 1);
    }
    void Start () {
		
	}
	
	void FixedUpdate () {
        
    }

    void Decide()
    {
        Invoke("Decide", 1);
        if (!grasped)
        {
            Debug.Log("Decide");
            body.velocity = Vector3.zero;
            body.velocity = speed * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        }
    }
}
