using Enemys.Rabbits;
using UnityEngine;

namespace Settings.SubSettings.Slider
{
    [CreateAssetMenu(fileName = "RabbitSliderAction", menuName = "RabbitSliderAction")]
    public class RabbitSliderAction : SliderActionSo
    {
        private WhiteRabbit _whiteRabbit;

        private void Awake()
        {
            _whiteRabbit = FindFirstObjectByType<WhiteRabbit>();
            if (_whiteRabbit == null)
            {
                Debug.LogError("WhiteRabbit not found in the scene!");
            }
        }

        public override void OnSliderValueChanged(float value, GameObject player)
        {
            if (value < 0.3f)
            {
                WhiteRabbit.checkVolume = true;
            }
            else
            {
                WhiteRabbit.checkVolume = false;
            }

            Debug.Log($"RabbitSliderAction: checkVolume set to {value < 0.3f}");
        }
    }
}