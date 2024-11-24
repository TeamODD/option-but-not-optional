using UnityEngine;
using UnityEngine.SceneManagement;

public class HintextDestroy : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Scene10")
        {
            Destroy(this);
            gameObject.SetActive(false);
        }
    }
}