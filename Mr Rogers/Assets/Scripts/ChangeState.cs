using HoloToolkit.Unity.InputModule.Examples.Grabbables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {

    [SerializeField]
    private BaseGrabbable _grabbable;
    private AI _ai;

    private void Awake()
    {
        if(_grabbable == null)
        {
            _grabbable = GetComponent<BaseGrabbable>();
        }
        if(_ai == null)
        {
            _ai = GetComponent<AI>();
        }

        _grabbable.OnContactStateChange += ChangeAnimationState;
        _grabbable.OnGrabStateChange += ChangeAnimationState;
    }
    
    private void ChangeAnimationState(BaseGrabbable baseGrab)
    {

        switch (baseGrab.GrabState)
        {
            case GrabStateEnum.Inactive:
                _ai.grabbed = false;
                break;

            case GrabStateEnum.Multi:
                _ai.grabbed = true;
                break;

            case GrabStateEnum.Single:
                _ai.grabbed = true;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
