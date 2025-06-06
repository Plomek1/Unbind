using System;
using UnityEngine;

namespace Unbind
{
    public abstract class TraitData : ScriptableObject
    {
        public TraitType type;
        public new string name;
        public Sprite icon;

        public abstract void AddTraitComponent(GameObject target, bool activeAtAwake);
    }

    public abstract class TraitData<T> : TraitData where T : TraitLogic
    {
        public override void AddTraitComponent(GameObject target, bool activeAtAwake)
        {
            if (!target.TryGetComponent(out T comp))
            {
                T logic = target.AddComponent<T>();
                logic.Init(activeAtAwake);
            }
        }
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
