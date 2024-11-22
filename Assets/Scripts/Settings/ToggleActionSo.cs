using UnityEngine;

namespace Settings
{
    public abstract class ToggleActionSo : ScriptableObject
    {
        public abstract void OnToggleValueChanged(bool value, GameObject player);
    }
}