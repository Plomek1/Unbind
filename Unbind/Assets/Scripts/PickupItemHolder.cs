using UnityEngine;

namespace Unbind
{
    public class PickupItemHolder : MonoBehaviour
    {
        [field: SerializeField] public Transform holdingPosition;

        private InteractionDetector interactionDetector;
        private PickupItem currentItem;

        private void Start()
        {
            interactionDetector = GetComponent<InteractionDetector>();
            Globals.Instance.inputReader.PlayerInteract += Drop;
        }

        public void Pickup(PickupItem item)
        {
            currentItem = item;
            interactionDetector.enabled = false;
        }

        public void Drop()
        {
            if (currentItem == null) return;
            
            currentItem.Drop();
            currentItem = null;
            interactionDetector.enabled = true;
        }
    }
}
