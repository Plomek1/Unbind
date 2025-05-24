using UnityEngine;

namespace Unbind
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Globals.Instance.inputReader.EnablePlayerActions();
            Globals.Instance.inputReader.ResetCallbacks();
        }
    }
}
