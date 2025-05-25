using UnityEngine;
using UnityEngine.Events;

namespace Unbind
{
    public class Interactable : MonoBehaviour
    {
        public UnityEvent<Transform> OnInteract;
        public UnityEvent<Transform> OnManageTraits;
        
        public UnityEvent OnFocus;
        public UnityEvent OnDefocus;

        public void Interact(Transform source)
        {
            OnInteract?.Invoke(source);
        }

        public void ManageTraits(Transform source)
        {
            OnManageTraits?.Invoke(source);
        }
        
        public void Focus()
        {
            OnFocus?.Invoke();
        }

        public void Defocus()
        {
            OnDefocus?.Invoke();
        }
    }
}
