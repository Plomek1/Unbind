using UnityEngine;

namespace Unbind
{
    public class GameManager : MonoBehaviour
    {
        public static bool cursorLocked {  get; private set; }

        private void Awake()
        {
            Globals.Instance.InputReader.EnablePlayerActions();
            Globals.Instance.InputReader.ResetCallbacks();
            LockCursor();
        }

        public static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            cursorLocked = true;
        }

        public static void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
            cursorLocked = false;
        }
    }
}
