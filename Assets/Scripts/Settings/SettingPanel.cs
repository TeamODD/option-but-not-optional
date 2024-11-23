using UnityEngine;

namespace Settings
{
    public class SettingPanel : MonoBehaviour
    {
        private static SettingPanel _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}