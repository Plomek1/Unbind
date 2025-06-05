using UnityEngine;

namespace Unbind
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityTraitScript : TraitScript
    {
        private Rigidbody rb;

        protected override void Init()
        {
            base.Init();
            type = TraitType.Gravity;
            if (!TryGetComponent(out rb))
                rb = gameObject.AddComponent<Rigidbody>();
        }

        protected override void Activate()
        {
            base.Activate();
            rb.useGravity = false;
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            rb.useGravity = true;
        }

    }
}
