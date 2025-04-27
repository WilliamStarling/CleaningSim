using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Throw;
using Unity.VisualScripting;
using UnityEngine;

//Old backup of the tweezer script that was trying to use force joints.
public class TweezeJoint : MonoBehaviour, IHandGrabUseDelegate
{
    private float _dampedUseStrength = 0;
    private float _lastUseTime;
    private AnimationCurve _strengthCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] private float _triggerSpeed = 3f;
    private bool canGrab = false;
    private bool inRange = false;
    private GameObject grabbableObject = null;
    private Rigidbody grabbableRB = null;
    [SerializeField] private GameObject defaultParent = null;
    [SerializeField] private FixedJoint fixedJoint;
    // Start is called before the first frame update
    void Start()
    {
        fixedJoint = this.GetComponent<FixedJoint>(); //The fixed joint that will be used to grab the object.
    }

    void GrabObject()
    {
        Debug.Log("Tweezers Grabbing object: " + grabbableObject.name);
        grabbableRB.useGravity = true; //Disable gravity on the object so it doesn't fall when grabbed.
        fixedJoint.connectedBody = grabbableRB; //Set the fixed joint to be connected to the object that is in range.
    }

    void ReleaseObject()
    {
        Debug.Log("Tweezers Dropping object: " + grabbableObject.name);
        fixedJoint.connectedBody = null; //Set the fixed joint to be disconnected from the object that was in range.
        grabbableRB.useGravity = true; //Enable gravity on the object so it falls when dropped.
        Rigidbody tweezerRB = this.GetComponent<Rigidbody>(); //Get the rigidbody of the tweezer.
        tweezerRB.velocity = Vector3.zero;
        tweezerRB.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        // Logic to handle when the Tweezer touches something it can grab.
        if(other.CompareTag("Component"))
        {
            Debug.Log("Grabbable entered Tweezer range: " + other.gameObject.name);
            grabbableObject = other.gameObject; //Get the object that is in range.
            grabbableRB = grabbableObject.GetComponent<Rigidbody>(); //Get the rigidbody of the object that is in range.
            inRange = true; //boolean to for checking when grip is pressed.
            if(canGrab)
            {
                //If the button is already pressed, grab the object.
                GrabObject();
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Logic to handle when the Tweezer leaves the object it can grab.
        if(other.CompareTag("Component"))
        {
            Debug.Log("Grabbable left tweezer range: " + other.gameObject.name);
            inRange = false; //update boolean so grabbing can't grab it now.
            if(canGrab)
            {
                ReleaseObject();
            }
            grabbableObject = null; //release the reference to object that was in range.
            grabbableRB = null; //release the reference to the rigidbody of the object that was in range.
        }
    }

    public void BeginUse()
    {
        _dampedUseStrength = 0f;
        _lastUseTime = Time.realtimeSinceStartup;
        // Logic to start using the tweezer
        Debug.Log("Tweezers being used!");
        canGrab = true;
        if(inRange)
        {
            GrabObject();
        }
    }

    public void EndUse()
    {
        // Logic to end using the tweezer
        Debug.Log("Tweezers stopped being used!");
        canGrab = false;
        if(inRange)
        {
            ReleaseObject();
        }
    }

    public float ComputeUseStrength(float strength)
    {
        float delta = Time.realtimeSinceStartup - _lastUseTime;
        _lastUseTime = Time.realtimeSinceStartup;
        if (strength > _dampedUseStrength)
        {
            _dampedUseStrength = Mathf.Lerp(_dampedUseStrength, strength, _triggerSpeed * delta);
        }
        else
        {
            _dampedUseStrength = strength;
        }
        float progress = _strengthCurve.Evaluate(_dampedUseStrength);
        return progress;
    }
}
