using UnityEngine;

namespace Unbind
{
    public class Menu : MonoBehaviour
    {
        [field: SerializeField] public MenuType type {  get; private set; }

        public virtual void Open(params object[] parameters)
        {
            gameObject.SetActive(true);
            Globals.Instance.InputReader.UICancelCallbacks.Add(UIManager.CloseMenu);
            GameManager.UnlockCursor();
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
            GameManager.LockCursor();
        }
    }
}
