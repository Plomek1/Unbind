using UnityEngine;

namespace Unbind
{
    public class GravityTraitLogic : TraitLogic
    {
        private Rigidbody rb;

        private bool hadRigidbodyBeforeInit;

        public override void Init(bool activeAtAwake)
        {
            base.Init(activeAtAwake);
            type = TraitType.Gravity;

            hadRigidbodyBeforeInit = TryGetComponent(out rb);
            if (!hadRigidbodyBeforeInit)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.interpolation = RigidbodyInterpolation.Interpolate;
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rb.linearDamping = 0.75f;
                rb.angularDamping = 0.75f;
            }

            if (activeAtAwake) Activate();
            else Deactivate();
        }

        protected override void Activate()
        {
            base.Activate();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            if (!hadRigidbodyBeforeInit) rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
            rb.useGravity = false;
        }

    }
}
