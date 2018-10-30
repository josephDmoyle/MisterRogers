using HoloToolkit.Unity.InputModule.Examples.Grabbables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {

    [SerializeField]
    private BaseGrabbable _grabbable;
    private AI_Person _ai;

    private void Awake()
    {
        if(_grabbable == null)
        {
            _grabbable = GetComponent<BaseGrabbable>();
        }
        if(_ai == null)
        {
            _ai = GetComponent<AI_Person>();
        }

        _grabbable.OnContactStateChange += ChangeAnimationState;
        _grabbable.OnGrabStateChange += ChangeAnimationState;
    }
    
    private void ChangeAnimationState(BaseGrabbable baseGrab)
    {
        switch (baseGrab.ContactState)
        {
            case GrabStateEnum.Inactive:
                _ai.pointed = false;
                break;

            case GrabStateEnum.Multi:
                _ai.pointed = true;
                break;

            case GrabStateEnum.Single:
                _ai.pointed = true;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        switch (baseGrab.GrabState)
        {
            case GrabStateEnum.Inactive:
                _ai.grasped = false;
                break;

            case GrabStateEnum.Multi:
                _ai.grasped = true;
                break;

            case GrabStateEnum.Single:
                _ai.grasped = true;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
