using Enemys.Rabbits;
using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "RabbitSliderAction", menuName = "RabbitSliderAction")]
    public class RabbitSliderAction : SliderActionSo
    {
        private WhiteRabbit _whiteRabbit;

        private void Awake()
        {
            _whiteRabbit = FindFirstObjectByType<WhiteRabbit>();
        }

        public override void OnSliderValueChanged(float value, GameObject player)
        {
            if (value < 0.3f)
            {
                _whiteRabbit.checkVolume = false;
            }
            else
            {
                _whiteRabbit.checkVolume = true;
            }
        }
    }
}