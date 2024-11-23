using Settings;
using StageActions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManagement : MonoBehaviour
    {
        public StageActionSo[] stageActions;
        [SerializeField] private GameObject player;
        [SerializeField] private SliderController[] sliders;
        [SerializeField] private ToggleController[] toggles;
        private int _currentStageIndex;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ApplyStageActions();
        }

        private void ApplyStageActions()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }

            if (stageActions == null || stageActions.Length <= _currentStageIndex ||
                stageActions[_currentStageIndex] == null)
            {
                return;
            }

            if (stageActions == null)
            {
                return;
            }

            var currentStageAction = stageActions[_currentStageIndex];

            Debug.LogError(currentStageAction.GetType());

            for (var i = 0; i < sliders.Length; i++)
            {
                sliders[i].SetAction(currentStageAction.sliderActions[i]);
            }

            for (var i = 0; i < toggles.Length; i++)
            {
                toggles[i].SetAction(currentStageAction.toggleActions[i]);
            }

            //씬 로드 후 호출해야돼 


            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            var playerPos = new Vector3(-6f, -1.89f, 0);
            var rigid = player.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                rigid.linearVelocity = Vector2.zero; // 속도 초기화
                rigid.position = playerPos; // Rigidbody2D의 위치 설정
            }

            player.transform.position = playerPos;
            Debug.Log($"Player repositioned to {player.transform.position}");
        }

        public void LoadNextStage()
        {
            _currentStageIndex++;

            if (_currentStageIndex >= stageActions.Length)
            {
                Debug.LogWarning("No more stages to load. Restarting from the first stage.");
            }

            var stageIndex = _currentStageIndex + 1;

            SceneManager.LoadScene($"Scene{stageIndex}");

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.LogWarning("OnSceneLoaded");
            ApplyStageActions();
            Debug.Log($"{_currentStageIndex}stage is Loaded");

            // Instantiate(player, playerPos, Quaternion.identity); 소환안하고 그냥 위치만 바꿈. 
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}