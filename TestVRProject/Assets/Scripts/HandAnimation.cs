using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference gripActionReference;
    [SerializeField] private InputActionReference triggerActionReference;
    private Animator animator;
    private string gripActionName = "Grip";
    private string triggerActionName = "Pinch";

    private void Awake()
    {
         animator = GetComponent<Animator>();
         if(animator == null)
         {
            Debug.LogError("Animator component not found on the GameObject.");
         }
    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null)
        {
            return; // Exit if animator is not set
        }

        float gripValue = gripActionReference.action.ReadValue<float>();
        float triggerValue = triggerActionReference.action.ReadValue<float>();
        // Clamp values to ensure they are between 0 & 1
        animator.SetFloat(gripActionName, gripValue);
        animator.SetFloat(triggerActionName, triggerValue);
    }
}
