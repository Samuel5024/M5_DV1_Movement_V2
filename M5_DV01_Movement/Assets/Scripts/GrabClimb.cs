using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using  UnityEngine.XR.Interaction.Toolkit.Interactables;


public class GrabClimb : MonoBehaviour
{
    // interactable holds XRSimpleInteractable component
    [SerializeField] XRSimpleInteractable interactable;
    private ClimbController climbController;
    private bool isGrabbing;
    private Vector3 handPosition;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        climbController = GetComponentInParent<ClimbController>();
        isGrabbing = false;    
    }

    public void Grab()
    {
        isGrabbing = true;
        // register hand posotion
        handPosition = InteractorPosition();
        climbController.Grab();
    }

    // get current hand position with the InteractorPosition function
    private Vector3 InteractorPosition()
    {
        List<IXRHoverInteractor> interactors = interactable.interactorsHovering;
        if(interactors.Count > 0)
            return interactors[0].transform.position;
        else
            return handPosition;
    }

    private void Update()
    {
        if(isGrabbing)
        {
            // calculate delta distance the hand controller (Interactor)
            // has moved since previous frame & pass distance to
            // climbController.Pull
            Vector3 delta = handPosition - InteractorPosition();
            climbController.Pull(delta);
            // update current hand position
            handPosition = InteractorPosition();
        }
    }

    public void Release()
    {
        isGrabbing = false;
        climbController.Release();
    }
}
