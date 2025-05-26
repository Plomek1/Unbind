using UnityEngine;

namespace Unbind
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField] private float followSpeed = 15f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float maxSpeed = 17.5f;

        private PickupItemHolder holder;
        private Transform holderPosition;

        private Rigidbody rb;
        bool isPickedUp;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.maxLinearVelocity = maxSpeed;
        }

        public void Pickup(Transform source)
        {
            holder = source.GetComponent<PickupItemHolder>();
            holder.Pickup(this);

            holderPosition = holder.holdingPosition;
            rb.useGravity = false;
            isPickedUp = true;

            gameObject.layer = LayerMask.NameToLayer("Default");
        }

        public void Drop()
        {
            holderPosition = null;
            rb.useGravity = true;
            isPickedUp = false;

            holder.Drop();
            holder = null;

            gameObject.layer = LayerMask.NameToLayer("Ground");
        }

        private void FixedUpdate()
        {
            if (!isPickedUp) return;

            Vector3 distanceToTarget = holderPosition.position - transform.position;
            rb.linearVelocity = distanceToTarget * followSpeed;

            rb.angularVelocity = Vector3.zero;

            Vector3 lookDirection = (holder.cameraPosition.position - transform.position).normalized;
            if (lookDirection.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
            }
        }
    }
}
