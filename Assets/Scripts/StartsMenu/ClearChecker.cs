using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearChecker : MonoBehaviour
{
    private bool clearChecker = true;
    public GameObject prefab;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "StartMenuScene")
        {
            clearChecker = !clearChecker;
        }
        if (clearChecker)
        {
            Instantiate(prefab, new Vector3(0, 7, 0), Quaternion.Euler(Vector3.zero));
        }
    }
}
