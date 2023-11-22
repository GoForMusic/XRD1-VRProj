using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0,1)] public float intensity;
    [Range(0,1)] public float duration;
    
    public void hapticEvent(BaseInteractionEventArgs eventArgs) // check 1
    {
        if (eventArgs.interactableObject is XRBaseControllerInteractor controllerInteractor)
        {
            sendHaptic(controllerInteractor.xrController);
        }
    }
    private void sendHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
public class HapticFeedback : MonoBehaviour
{
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticHoverExited;
    public Haptic hapticSelectEntered;
    public Haptic hapticSelectExited;

    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.hapticEvent);
        interactable.hoverEntered.AddListener(hapticHoverEntered.hapticEvent);
        interactable.hoverExited.AddListener(hapticHoverExited.hapticEvent);
        interactable.selectEntered.AddListener(hapticSelectEntered.hapticEvent);
        interactable.selectExited.AddListener(hapticSelectExited.hapticEvent);


    }

    
}
