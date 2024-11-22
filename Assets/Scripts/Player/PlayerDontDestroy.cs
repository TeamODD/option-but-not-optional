using UnityEngine;

namespace Player
{
    public class PlayerDontDestroy : MonoBehaviour
    {
        private static PlayerDontDestroy _instance;

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