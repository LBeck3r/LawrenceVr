using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty PinchAnimationAction;
    public InputActionProperty GripAnimationAction;

    public Animator HandAnimator;

    void Update()
    {
        var triggerValue = PinchAnimationAction.action.ReadValue<float>();
        var gripValue = GripAnimationAction.action.ReadValue<float>();

        HandAnimator.SetFloat("Trigger", triggerValue);
        HandAnimator.SetFloat("Grip", gripValue);
    }
}
