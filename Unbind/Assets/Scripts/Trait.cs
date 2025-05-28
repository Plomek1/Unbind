using System;
using UnityEngine;

namespace Unbind
{
    [CreateAssetMenu(fileName = "Trait", menuName = "Data/Trait")]
    public class Trait : ScriptableObject
    {
        public TraitType type;
        public new string name;
        public Sprite icon;
    }

    [Flags]
    public enum TraitType
    {
        None = 0,
        Gravity = 1,
        Reflection = 2,
        Velocity = 4,
    }
}
