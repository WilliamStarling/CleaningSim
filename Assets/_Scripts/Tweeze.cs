using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Editor;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Throw;
using Unity.VisualScripting;
using UnityEngine;

public class Tweeze : MonoBehaviour, IHandGrabUseDelegate
{
    private float _dampedUseStrength = 0;
    private float _lastUseTime;
    private AnimationCurve _strengthCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] private float _triggerSpeed = 3f;
    [SerializeField] private bool canGrab = false;
    [SerializeField] private bool inRange = false;
    private GameObject grabbableObject = null;
    private Rigidbody grabbableRB = null;
    [SerializeField] private Transform defaultParent;
    // Start is called before the first frame update

    void GrabObject()
    {
        //Debug.Log("Tweezers Grabbing object: " + grabbableObject.name);
        grabbableRB.useGravity = false; //Disable gravity on the object so it doesn't fall when grabbed.
        grabbableRB.isKinematic = true; //Set the object to be kinematic so it doesn't move when grabbed.
        grabbableRB.velocity = Vector3.zero; //reset the velocity so it is frozen
        grabbableRB.angularVelocity = Vector3.zero; //reset the angular velocity so it is frozen
        grabbableObject.transform.SetParent(this.transform); //Set the parent of the object to be the tweezer.
    }

    void ReleaseObject()
    {
        //Debug.Log("Tweezers Dropping object: " + grabbableObject.name);
        grabbableObject.transform.SetParent(defaultParent); //Set the fixed joint to be disconnected from the object that was in range.
        grabbableRB.useGravity = true; //Enable gravity on the object so it falls when dropped.
        grabbableRB.isKinematic = false; //Set the object to be non-kinematic so it can move when dropped.
    }

    void OnTriggerEnter(Collider other)
    {
        // Logic to handle when the Tweezer touches something it can grab.
        if(other.CompareTag("Component"))
        {
            grabbableObject = other.transform.parent.gameObject; //Get the Game object of the parent of the collider that is in range.
            grabbableRB = other.gameObject.GetComponent<Rigidbody>(); //Get the rigidbody of the object that is in range.
            //Debug.Log("Grabbable entered Tweezer range: " + grabbableObject.name);
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
            //Debug.Log("Grabbable left tweezer range: " + grabbableObject.name);
            inRange = false; //update boolean so grabbing can't grab it now.
            ReleaseObject();
            grabbableObject = null; //release the reference to object that was in range.
            //grabbableRB = null; //release the reference to the rigidbody of the object that was in range.
        }
    }

    void FixedUpdate()
    {
        if(grabbableRB.isKinematic == true && !(canGrab && inRange))
        {
            grabbableRB.isKinematic = false; //Set the object to be non-kinematic so it can move when dropped.
            //If the object is kinematic and the tweezer is not in range, release the object
            //(There's a bug where the object floats if it's "pulled out" of the tweezers, so have to do this manually)
        }
    }

    public void BeginUse()
    {
        _dampedUseStrength = 0f;
        _lastUseTime = Time.realtimeSinceStartup;
        // Logic to start using the tweezer
        //Debug.Log("Tweezers being used!");
        canGrab = true;
        if(inRange)
        {
            GrabObject();
        }
    }

    public void EndUse()
    {
        // Logic to end using the tweezer
        //Debug.Log("Tweezers stopped being used!");
        canGrab = false;
        ReleaseObject();
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
