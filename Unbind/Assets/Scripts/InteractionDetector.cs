using UnityEngine;

namespace Unbind
{
    public class InteractionDetector : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float interactionRange;

        private Interactable interactableFocused;

        private void Start()
        {
            Globals.Instance.inputReader.PlayerInteract += Interact;
            Globals.Instance.inputReader.PlayerManageTraits += ManageTraits;
        }

        private void Interact()
        {
            if (interactableFocused == null) return;
            interactableFocused.Interact(transform);
        }

        private void ManageTraits()
        {
            if (interactableFocused == null) return;
            interactableFocused.ManageTraits(cameraTransform);
        }

        private void Update()
        {
            Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hitInfo, interactionRange);
            if (hitInfo.collider)
            {
                if (interactableFocused?.transform != hitInfo.collider.transform &&  hitInfo.collider.TryGetComponent(out Interactable targetInteractable))
                {
                    interactableFocused?.Defocus();
                    targetInteractable.Focus();
                    interactableFocused = targetInteractable;
                }
            }
            else
            {
                interactableFocused?.Defocus();
                interactableFocused = null;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(cameraTransform.position, cameraTransform.position + cameraTransform.forward * interactionRange);
        }
    }
}
