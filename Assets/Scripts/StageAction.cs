using UnityEngine;

namespace DefaultNamespace
{
    public abstract class StageAction : ScriptableObject
    {
        public abstract void Execute(GameObject player);
    }
}