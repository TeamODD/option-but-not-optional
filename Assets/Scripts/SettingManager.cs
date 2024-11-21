using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager instance;

    private void Awake()
    {
      
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}