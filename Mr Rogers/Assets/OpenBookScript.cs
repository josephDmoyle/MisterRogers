using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBookScript : MonoBehaviour {


    private float RightTrigger;
    private float LeftTrigger;
    private float strttime;

    float flag = 0;
    private Animator anim;
    private bool open = true;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        strttime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        RightTrigger = Input.GetAxis("CONTROLLER_RIGHT_TRIGGER");
        LeftTrigger = Input.GetAxis("CONTROLLER_LEFT_TRIGGER");
        
        if(open && (RightTrigger == 1 || LeftTrigger == 1))
        {
            anim.SetTrigger("Open");
            open = false;
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("BookOPen"))
        {
            flag += (Time.time - strttime) * 2f;
            
        }

        if (flag>3000)
        {
            SceneManager.LoadScene("LevelTest"); 
            Debug.Log("STOPPPEd");
        }
    }
}
