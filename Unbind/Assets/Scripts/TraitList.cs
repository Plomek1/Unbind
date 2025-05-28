using UnityEngine;

namespace Unbind
{
    [CreateAssetMenu(fileName = "TraitList", menuName = "Data/TraitList")]
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
