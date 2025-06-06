using System;
using UnityEngine;

namespace Unbind
{
    public class ObjectTraitsManager : MonoBehaviour
    {
        public Action<TraitType> TraitsUpdated;

        [field:SerializeField] 
        public TraitType startTraits { get; private set; }
        public TraitType currentTraits {  get; private set; }

        private void Start()
        {
            currentTraits = startTraits;
            foreach (TraitType trait in currentTraits.GetFlags())
                AddTraitScript(trait);
        }

        public void AddTrait(TraitType trait)
        {
            if (currentTraits.HasFlag(trait)) return;
            AddTraitScript(trait);
            currentTraits |= trait;
            TraitsUpdated?.Invoke(currentTraits);
        }

        public void RemoveTrait(TraitType trait)
        {
            if (!currentTraits.HasFlag(trait)) return;
            currentTraits &= ~trait;
            TraitsUpdated?.Invoke(currentTraits);
        }

        private void AddTraitScript(TraitType trait, bool activeAtAwake = true) => Globals.Instance.TraitList.GetTrait(trait).AddTraitComponent(gameObject, activeAtAwake);
    }
}
