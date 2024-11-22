using UnityEngine;
using UnityEngine.SceneManagement;

public class StageStart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
        Debug.Log("Game Start");
    }
}