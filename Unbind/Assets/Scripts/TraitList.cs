using UnityEngine;

namespace Unbind
{
    [CreateAssetMenu(fileName = "_TraitList", menuName = "Traits/Trait List")]
    public class TraitList : ScriptableObject
    {
        [SerializeField] private TraitData[] traits;

        public TraitData GetTrait(TraitType type)
        {
            
            foreach (TraitData trait in traits)
            {
                if (trait.type == type)
                    return trait;
            }
            return null;
        }
    }
}
