using UnityEngine;

namespace Unbind
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField] private float followSpeed = 15f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float maxSpeed = 20f;

        private PickupItemHolder holder;
        private Transform holderPosition;
        private ObjectTraitsManager traitsManager;

        private Rigidbody rb;
        bool isPickedUp;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.maxLinearVelocity = maxSpeed;

            traitsManager = GetComponent<ObjectTraitsManager>();
        }

        public void Pickup(Transform source)
        {
            if (isPickedUp) return;

            holder = source.GetComponent<PickupItemHolder>();
            holder.Pickup(this);

            holderPosition = holder.holdingPosition;
            isPickedUp = true;
            rb.useGravity = false;

            gameObject.layer = LayerMask.NameToLayer("Default");
        }

        public void Drop()
        {
            if (!isPickedUp) return;
            
            holderPosition = null;
            isPickedUp = false;

            if (traitsManager.unboundTrait != TraitType.Gravity)
                rb.useGravity = true;

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
