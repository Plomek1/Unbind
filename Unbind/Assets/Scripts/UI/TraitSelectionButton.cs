using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unbind
{
    public class TraitSelectionButton : MonoBehaviour
    {
        public Action<TraitType> TraitSelected;

        [SerializeField] private TMP_Text traitNameLabel;

        private TraitType trait;

        public void SetTrait(TraitType traitType, bool active, bool additional)
        {
            trait = traitType;
            TraitData traitData = Globals.Instance.TraitList.GetTrait(traitType);
            
            traitNameLabel.text = traitData.name;
            if (!active)
                GetComponent<Button>().enabled = false;
            if (additional)
                GetComponent<Image>().color = Color.yellow;
            
        }

        public void SelectTrait()
        {
            TraitSelected?.Invoke(trait);
        }
    }
}
