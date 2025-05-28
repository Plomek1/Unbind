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

        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public TraitList TraitList { get; private set; }

    }
}
