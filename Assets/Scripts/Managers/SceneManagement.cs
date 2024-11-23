using Settings;
using StageActions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManagement : SingleTonManager<SceneManagement>
    {
        public StageActionSo[] stageActions;
        [SerializeField] private GameObject player;
        [SerializeField] private SliderController[] sliders;
        [SerializeField] private ToggleController[] toggles;

        private int _currentStageIndex;


        private void Start()
        {
            ApplyStageActions();
        }

        private void ApplyStageActions()
        {
            if (stageActions == null || stageActions.Length <= _currentStageIndex ||
                stageActions[_currentStageIndex] == null)
            {
                Debug.LogWarning("No valid stage action found for the current stage index.");
                return;
            }

            if (stageActions == null)
            {
                return;
            }

            var currentStageAction = stageActions[_currentStageIndex];

            for (var i = 0; i < sliders.Length; i++)
            {
                sliders[i].SetAction(currentStageAction.sliderActions[i]);
            }

            for (var i = 0; i < toggles.Length; i++)
            {
                toggles[i].SetAction(currentStageAction.toggleActions[i]);
            }
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
            ApplyStageActions();
            Debug.Log($"{_currentStageIndex}stage is Loaded");
            var playerPos = new Vector3(-6f, -1.89f, 0);
            // Instantiate(player, playerPos, Quaternion.identity); 소환안하고 그냥 위치만 바꿈. 
            player.transform.position = playerPos;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}