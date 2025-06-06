using UnityEngine;
using UnityEngine.Events;

namespace Unbind
{
    public class Interactable : MonoBehaviour
    {
        [field: SerializeField] public bool canBeSelected {  get; private set; }
        [Space(15)]

        public UnityEvent<Transform> OnSelect;
        public UnityEvent            OnDeselect;
        
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
