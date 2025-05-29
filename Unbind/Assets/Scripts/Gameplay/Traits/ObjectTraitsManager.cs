using System;
using UnityEngine;

namespace Unbind
{
    public class ObjectTraitsManager : MonoBehaviour
    {
        public Action<TraitType> TraitUnbound;

        [field: SerializeField] public TraitType traits       {  get; private set; }
        [field: SerializeField] public TraitType unboundTrait {  get; private set; }

        public void OpenTraitsMenu()
        {
            TraitSelectionMenu traitSelectionMenu = UIManager.OpenMenu(MenuType.TraitSelectionMenu, traits, unboundTrait) as TraitSelectionMenu;
            traitSelectionMenu.TraitSelected += UnbindTrait;
        }

        private void UnbindTrait(TraitType type)
        {
            if (!traits.HasFlag(type)) return;
            unboundTrait = type == unboundTrait ? TraitType.None : type;
            TraitUnbound?.Invoke(unboundTrait);
        }
    }
}
