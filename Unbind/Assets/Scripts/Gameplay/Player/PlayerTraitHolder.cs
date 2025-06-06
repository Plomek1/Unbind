using System;
using UnityEngine;

namespace Unbind
{
    [RequireComponent(typeof(PlayerInteractionTrigger))]
    public class PlayerTraitHolder : MonoBehaviour
    {
        public Action<TraitType> TraitChanged;

        private TraitType currentTrait;

        private PlayerInteractionTrigger interactionTrigger;
        private ObjectTraitsManager selectedObject;

        private void Start()
        {
            interactionTrigger = GetComponent<PlayerInteractionTrigger>();
            Globals.Instance.InputReader.PlayerManageTraits += HandleTraitSelection;
        }

        private void HandleTraitSelection()
        {
            if (UIManager.menuOpened) return;

            Interactable currentInteractable = interactionTrigger.GetCurrentInteractable();
            if (currentInteractable && currentInteractable.TryGetComponent(out selectedObject))
            {
                if (currentTrait == TraitType.None)
                {
                    if (selectedObject.currentTraits == TraitType.None)
                    {
                        Debug.Log("OBJECT HAS NO TRAITS");
                        return;
                    }

                    TraitSelectionMenu menu = UIManager.OpenMenu(MenuType.TraitSelectionMenu, selectedObject.startTraits, selectedObject.currentTraits) as TraitSelectionMenu;
                    menu.TraitSelected += RemoveTraitFromObject;
                }
                else
                {
                    if (selectedObject.currentTraits.HasFlag(currentTrait))
                    {
                        Debug.Log("OBJECT ALREADY HAS THIS TRAIT");
                        return;
                    }

                    selectedObject.AddTrait(currentTrait);
                    selectedObject = null;
                    currentTrait = TraitType.None;
                }
            }
        }

        private void RemoveTraitFromObject(TraitType trait)
        {
            selectedObject.RemoveTrait(trait);
            currentTrait = trait;
        }
    }
}
