using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    public XRBaseController rightController;
    public XRBaseController leftController;

    public static HapticFeedback instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Multiple haptic event singletons");
            Destroy(this);
        }
        //XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        //interactable.activated.AddListener(TriggerHaptic);
    }
    /*
    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if(eventArgs.interactableObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }
    */

    public void RightControllerHapticEvent(float intensity, float duration) { HapticEvent(rightController, intensity, duration); }
    public void LefttControllerHapticEvent(float intensity, float duration) { HapticEvent(leftController, intensity, duration); }

    public void HapticEvent(XRBaseController controller, float intensity, float duration)
    {
        if (intensity > 0)
            controller.SendHapticImpulse(intensity, duration);
    }


}
