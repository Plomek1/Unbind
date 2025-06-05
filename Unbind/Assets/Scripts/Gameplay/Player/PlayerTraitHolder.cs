using System;
using UnityEngine;

namespace Unbind
{
    public class PlayerTraitHolder : MonoBehaviour
    {
        public Action<TraitType> TraitChanged;

        private TraitType currentTrait;

        public void TriggerTrait(ObjectTraitsManager source)
        {
            
        }
    }
}
