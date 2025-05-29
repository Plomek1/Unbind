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
            rb = GetComponent<Rigidbody>();
        }

        protected override void UnbindTrait()
        {
            base.UnbindTrait();
            rb.useGravity = false;
        }

        protected override void BindTrait()
        {
            base.BindTrait();
            rb.useGravity = true;
        }

    }
}
