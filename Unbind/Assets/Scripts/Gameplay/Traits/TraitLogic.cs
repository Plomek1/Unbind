using UnityEngine;

namespace Unbind
{
    [RequireComponent(typeof(ObjectTraitsManager))]
    public class TraitLogic : MonoBehaviour
    {
        protected TraitType type = TraitType.None;
        protected bool active = false;

        public virtual void Init(bool activeAtAwake)
        {
            GetComponent<ObjectTraitsManager>().TraitsUpdated += OnTraitsUpdated;
            active = activeAtAwake;
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
                Deactivate();
            else
                Activate();
        }

        private void OnTraitsUpdated(TraitType currentTraits)
        {
            if (currentTraits.HasFlag(type) != active)
                ToggleTrait();
        }
    }
}
