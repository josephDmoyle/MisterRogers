using HoloToolkit.Unity.InputModule.Examples.Grabbables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Grasped : BaseGrabbable
{

    private Rigidbody _rigidbody;
    private AI_Person _ai; 
    [SerializeField]
    private bool matchPosition = true;
    [SerializeField]
    private bool matchRotation = false;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody>();
        _ai = GetComponent<AI_Person>();
    }


    /// <summary>
    /// Specify the target and turn off gravity. Otherwise gravity will interfere with desired grab effect
    /// </summary>
    protected override void StartGrab(BaseGrabber grabber)
    {
        base.StartGrab(grabber);
        if (_rigidbody)
        {
            _rigidbody.useGravity = false;
        }
        if(_ai)
        {
            _ai.pointed = false;
            _ai.grasped = true;
        }
    }

    /// <summary>
    /// On release turn gravity back on the so the object falls and set the target back to null
    /// </summary>
    protected override void EndGrab()
    {
        if (_rigidbody)
        {
            _rigidbody.useGravity = true;
        }
        if(_ai)
        {
            _ai.grasped = false;
        }
        base.EndGrab();
    }

    protected override void OnGrabStay()
    {
        transform.position = Vector3.Lerp(transform.position, GrabberPrimary.GrabHandle.position, Time.time / (5 * 1000));
    }

    // The next two functions provide basic behaviour. Extend from this base script in order to provide more specific functionality.

    protected override void AttachToGrabber(BaseGrabber grabber)
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        _rigidbody.isKinematic = true;
        if (!activeGrabbers.Contains(grabber))
        {
            activeGrabbers.Add(grabber);
        }
    }

    protected override void DetachFromGrabber(BaseGrabber grabber)
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
    }
}

