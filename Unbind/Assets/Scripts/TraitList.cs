using UnityEngine;

namespace Unbind
{
    [CreateAssetMenu(fileName = "_TraitList", menuName = "Traits/Trait List")]
    public class TraitList : ScriptableObject
    {
        [SerializeField] private Trait[] traits;

        public Trait GetTrait(TraitType type)
        {
            
            foreach (Trait trait in traits)
            {
                if (trait.type == type)
                    return trait;
            }
            return null;
        }
    }
}
