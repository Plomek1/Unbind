using UnityEngine;

namespace Unbind
{
    [RequireComponent(typeof(ObjectTraitsManager))]
    public class TraitScript : MonoBehaviour
    {
        protected TraitType type = TraitType.None;
        protected bool unbound = false;

        protected virtual void Init()
        {
            GetComponent<ObjectTraitsManager>().TraitUnbound += OnTraitUnbound;
        }

        protected virtual void UnbindTrait()
        {
            unbound = true;
        }

        protected virtual void BindTrait()
        {
            unbound = false;
        }

        private void OnTraitUnbound(TraitType unboundTraitType)
        {
            if (type == unboundTraitType)
                if (unbound) BindTrait(); else UnbindTrait();
            else
                if (unbound) BindTrait();
        }

        private void Start() => Init();
    }
}
