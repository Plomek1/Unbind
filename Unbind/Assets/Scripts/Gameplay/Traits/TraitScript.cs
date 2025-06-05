using UnityEngine;

namespace Unbind
{
    [RequireComponent(typeof(ObjectTraitsManager))]
    public class TraitScript : MonoBehaviour
    {
        protected TraitType type = TraitType.None;
        protected bool active = false;

        protected virtual void Init()
        {
            GetComponent<ObjectTraitsManager>().TraitUnbound += OnTraitUnbound;
            Deactivate();
        }

        protected virtual void Activate()
        {
            active = true;
        }

        protected virtual void Deactivate()
        {
            active = false;
        }

        protected virtual void ToggleTrait()
        {
            if (active)
                Activate();
            else
                Deactivate();
        }

        private void OnTraitUnbound(TraitType currentTraits)
        {
            if (currentTraits.HasFlag(type) != active)
                ToggleTrait();
        }

        private void Start() => Init();
    }
}
