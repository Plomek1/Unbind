using System;
using UnityEngine;

namespace Unbind
{
    public class ObjectTraitsManager : MonoBehaviour
    {
        public Action<TraitType> TraitUnbound;

        public TraitType currentTraits {  get; private set; }

        [SerializeField] public TraitType startTraits;

        private void Start()
        {
            currentTraits = startTraits;
            foreach (TraitType trait in currentTraits.GetFlags())
                AddTraitScript(trait);
        }

        public void OpenTraitsMenu()
        {
            TraitSelectionMenu traitSelectionMenu = UIManager.OpenMenu(MenuType.TraitSelectionMenu, startTraits, currentTraits) as TraitSelectionMenu;
            traitSelectionMenu.TraitSelected += UnbindTrait;
        }

        private void UnbindTrait(TraitType trait)
        {
            //TODO FIX
            currentTraits = currentTraits.HasFlag(trait) ? currentTraits & ~trait : currentTraits | trait;
            TraitUnbound?.Invoke(currentTraits);
        }

        private void AddTraitScript(TraitType trait) => Globals.Instance.TraitList.GetTrait(trait).AddTraitComponent(gameObject);
    }
}
