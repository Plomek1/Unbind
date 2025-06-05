using System;
using UnityEngine;

namespace Unbind
{
    public abstract class Trait : ScriptableObject
    {
        public TraitType type;
        public new string name;
        public Sprite icon;

        public abstract void AddTraitComponent(GameObject target);
    }

    public abstract class Trait<T> : Trait where T : TraitScript
    {
        public override void AddTraitComponent(GameObject target)
        {
            if (!target.TryGetComponent(out T comp))
                target.AddComponent<T>();
        }
    }

    [CreateAssetMenu(fileName = "Trait", menuName = "Traits/Gravity Trait")]
    public class GravityTrait : Trait<GravityTraitScript> {  }

    [CreateAssetMenu(fileName = "Trait", menuName = "Traits/Reflection Trait")]
    public class ReflectionTrait : Trait<GravityTraitScript> { }

    [Flags]
    public enum TraitType
    {
        None = 0,
        Gravity = 1,
        Reflection = 2,
        Velocity = 4,
    }
}
