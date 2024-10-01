using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    public Animator animator;
    public string boolName = "Open";

    private void Start()
    {
        
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener
                                                        (x => ToggleDoorOpen());
    }

    public void ToggleDoorOpen()
    {
        Debug.Log("ToggleDoorOpen called");
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);
        Debug.Log("Door is now " + (!isOpen ? "open" : "closed"));
    }
}
