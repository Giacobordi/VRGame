using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandAnimated : MonoBehaviour
{
    public InputActionProperty GrabHandAnimation;
    public InputActionProperty PinchHandAnimation;
    public Animator handAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float TriggerValue = GrabHandAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", TriggerValue);
        float TriggerValue2 = PinchHandAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", TriggerValue2);
    }
}
