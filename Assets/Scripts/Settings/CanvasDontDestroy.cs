using UnityEngine;

namespace Settings
{
    public class CanvasDontDestroy : MonoBehaviour
    {
        private static CanvasDontDestroy _instance;

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