using System;
using TMPro;
using UnityEngine;

namespace Unbind
{
    public class TraitSelectionButton : MonoBehaviour
    {
        public Action<TraitType> TraitSelected;

        [SerializeField] private TMP_Text traitNameLabel;

        private TraitType trait;

        public void SetTrait(TraitType traitType, bool unbound)
        {
            trait = traitType;
            Trait traitData = Globals.Instance.TraitList.GetTrait(traitType);
            
            traitNameLabel.text = traitData.name;
            if (unbound)
                traitNameLabel.text += " (Currently Unbound)";
        }

        public void SelectTrait()
        {
            TraitSelected?.Invoke(trait);
        }
    }
}
