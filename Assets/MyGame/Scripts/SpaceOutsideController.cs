using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;

    public float forwardSpeed;
    public float sideSpeed;

    private bool wasOn;

    private void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) 
                                    * Mathf.Lerp(-1, 1, knob.value);

        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;


        if (lever.value != wasOn)
        {
            if (lever.value)
            {
                AudioManager.instance.Play("Space Ship Engine");
            }
            else
            {
                AudioManager.instance.Stop("Space Ship Engine");
            }
        }

        wasOn = lever.value;
    }
}
