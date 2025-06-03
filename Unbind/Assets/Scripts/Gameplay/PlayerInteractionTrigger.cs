using UnityEngine;

namespace Unbind
{
    public class PlayerInteractionTrigger : MonoBehaviour
    {
        [HideInInspector] public bool canSelect = true;
        [HideInInspector] public bool canManageTraits = true;

        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float interactionRange;

        private Interactable interactableFocused;
        private Interactable interactableSelected;

        private CharacterController characterController;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            Globals.Instance.InputReader.PlayerInteract += Select;
            Globals.Instance.InputReader.PlayerManageTraits += ManageTraits;
        }

        private void Select()
        {
            if (!GameManager.cursorLocked) return;

            if (interactableSelected)
            {
                interactableSelected.Deselect();
                interactableSelected = null;
                return;
            }

            if (!canSelect || interactableFocused == null) return;
            interactableFocused.Select(transform);
            interactableSelected = interactableFocused;
        }

        private void ManageTraits()
        {
            if (!GameManager.cursorLocked) return;

            if (interactableSelected)
            {
                interactableSelected.ManageTraits(transform);
                return;
            }

            if (!canManageTraits || interactableFocused == null) return;
            interactableFocused.ManageTraits(cameraTransform);
        }

        private void Update()
        {
            //Disabling collision detection so raycast wont return player object
            characterController.detectCollisions = false;
            Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hitInfo, interactionRange);
            characterController.detectCollisions = true;


            if (interactableFocused && hitInfo.collider?.transform != interactableFocused.transform)
            {
                interactableFocused.Defocus();
                interactableFocused = null;
            }

            if (hitInfo.collider && hitInfo.collider.TryGetComponent(out Interactable targetInteractable))
            {
                interactableFocused = targetInteractable;
                targetInteractable.Focus();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(cameraTransform.position, cameraTransform.position + cameraTransform.forward * interactionRange);
        }
    }
}
