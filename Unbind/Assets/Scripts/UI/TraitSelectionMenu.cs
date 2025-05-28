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

        // 1st param - all traits of an object
        // 2nd param - currently unbound trait
        public override void Open(params object[] parameters)
        {
            base.Open(parameters);
            Time.timeScale = 0f;

            TraitType unboundTrait = (TraitType)parameters[1];

            foreach (TraitType trait in ((TraitType)parameters[0]).GetFlags())
            {
                TraitSelectionButton btn = Instantiate(traitSelectionButtonPrefab, traitSelectionButtonList).GetComponent<TraitSelectionButton>();
                btn.SetTrait(trait, trait == unboundTrait);
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
