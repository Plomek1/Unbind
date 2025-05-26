using UnityEngine;
using UnityEngine.Events;

namespace Unbind
{
    public class Interactable : MonoBehaviour
    {
        public UnityEvent<Transform> OnSelect;
        public UnityEvent            OnDeselect;
        public UnityEvent<Transform> OnManageTraits;
        
        public UnityEvent OnFocus;
        public UnityEvent OnDefocus;

        public void Select(Transform source)
        {
            OnSelect.Invoke(source);
        }

        public void Deselect()
        {
            OnDeselect.Invoke();
        }

        public void ManageTraits(Transform source)
        {
            OnManageTraits.Invoke(source);
        }
        
        public void Focus()
        {
            OnFocus.Invoke();
        }

        public void Defocus()
        {
            OnDefocus.Invoke();
        }
    }
}
