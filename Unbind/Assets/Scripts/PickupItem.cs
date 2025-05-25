using UnityEngine;

namespace Unbind
{
    public class PickupItem : MonoBehaviour
    {
        private Transform holderPosition;
        bool isPickedUp;

        public void Pickup(Transform source)
        {
            PickupItemHolder holder = source.GetComponent<PickupItemHolder>();
            holder.Pickup(this);
            holderPosition = holder.holdingPosition;
            isPickedUp = true;
        }

        public void Drop()
        {
            holderPosition = null;
            isPickedUp = false;
        }

        private void Update()
        {
            if (!isPickedUp) return;
            transform.position = holderPosition.position;
        }
    }
}
