using Settings;
using StageActions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManagement : SingleTonManager<SceneManagement>
    {
        public StageActionSo currentStageAction;
        [SerializeField] private GameObject _player;
        [SerializeField] private SliderController[] sliders;

        private void Start()
        {
            ApplyStageActions();
        }

        private void ApplyStageActions()
        {
            if (currentStageAction == null)
            {
                return;
            }

            for (var i = 0; i < sliders.Length; i++)
            {
                sliders[i].SetAction(currentStageAction.sliderActions[i]);
            }
        }

        public void LoadNextStage()
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}