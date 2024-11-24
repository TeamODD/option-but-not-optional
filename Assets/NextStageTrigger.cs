using Managers;
using UnityEngine;

public class NextStageTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player와 충돌했는지 확인
        {
            var sceneManager = FindFirstObjectByType<SceneManagement>();
            if (sceneManager != null)
            {
                sceneManager.LoadNextStage(); // SceneManagement의 LoadNextStage 호출
            }
            else
            {
                Debug.LogError("SceneManagement not found in the scene!");
            }
        }
    }
}