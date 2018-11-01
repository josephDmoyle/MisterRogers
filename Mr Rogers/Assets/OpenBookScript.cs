using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBookScript : MonoBehaviour {


    private float RightTrigger;
    private float LeftTrigger;

   private float anim_time = 4.128f;
    private float at_anim;
    private Animator anim;
    private bool open = true;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        RightTrigger = Input.GetAxis("CONTROLLER_RIGHT_TRIGGER");
        LeftTrigger = Input.GetAxis("CONTROLLER_LEFT_TRIGGER");
        
        if(open && (RightTrigger == 1 || LeftTrigger == 1))
        {
            at_anim = Time.time + anim_time;
            anim.SetTrigger("Open");
            open = false;
        }


        if (!open && Time.time > at_anim)
        {
            SceneManager.LoadScene("LevelTest");
        }

      
    }
}
