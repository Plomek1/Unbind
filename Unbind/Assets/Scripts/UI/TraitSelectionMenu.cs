using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unbind
{
    public class TraitSelectionMenu : Menu
    {
        public Action<TraitType> TraitSelected;

        [SerializeField] private RectTransform traitSelectionButtonList;
        [SerializeField] private TraitSelectionButton traitSelectionButtonPrefab;

        private void SelectTrait(TraitType trait)
        {
            TraitSelected?.Invoke(trait);
            UIManager.CloseMenu();
        }

        public override void Open(params object[] parameters)
        {
            TraitType startTraits = (TraitType)parameters[0];
            TraitType currentTraits = (TraitType)parameters[1];

            base.Open(parameters);
            Time.timeScale = 0f;

            //Displaying all default traits
            foreach (TraitType trait in (startTraits).GetFlags())
            {
                TraitSelectionButton btn = Instantiate(traitSelectionButtonPrefab, traitSelectionButtonList).GetComponent<TraitSelectionButton>();
                btn.SetTrait(trait, currentTraits.HasFlag(trait), false);
                currentTraits = currentTraits & ~trait;
                btn.TraitSelected += SelectTrait;
            }

            //Displaying all additional traits
            foreach (TraitType trait in (currentTraits).GetFlags())
            {
                TraitSelectionButton btn = Instantiate(traitSelectionButtonPrefab, traitSelectionButtonList).GetComponent<TraitSelectionButton>();
                btn.SetTrait(trait, true, true);
                btn.TraitSelected += SelectTrait;
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(traitSelectionButtonList);
        }

        public override void Close()
        {
            foreach (Transform child in traitSelectionButtonList)
                Destroy(child.gameObject);
            TraitSelected = null;

            Time.timeScale = 1f;
            base.Close();
        }
    }
}
