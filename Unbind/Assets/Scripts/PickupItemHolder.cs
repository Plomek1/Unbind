using UnityEngine;

namespace Unbind
{
    public class PickupItemHolder : MonoBehaviour
    {
        [field: SerializeField] public Transform holdingPosition;
        [field: SerializeField] public Transform cameraPosition;

        private PlayerInteractionTrigger interactionDetector;
        private PickupItem currentItem;

        private void Start()
        {
            interactionDetector = GetComponent<PlayerInteractionTrigger>();
        }

        public void Pickup(PickupItem item)
        {
            currentItem = item;
            interactionDetector.canSelect = false;
        }

        public void Drop()
        {
            if (currentItem == null) return;
            
            currentItem = null;
            interactionDetector.canSelect = true;
        }
    }
}
