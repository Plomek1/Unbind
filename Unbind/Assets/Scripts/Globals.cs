using UnityEngine;

namespace Unbind
{
    public class Globals : MonoBehaviour
    {
        private static Globals _instance;

        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Instantiate((GameObject)Resources.Load("Globals")).GetComponent<Globals>();
                return _instance;
            }
        }

        [Header("Prefabs")]
        [field: SerializeField] public InputReader inputReader { get; private set; }
    }
}
