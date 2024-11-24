using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "SizeControlAction", menuName = "SizeControlAction")]
    public class SizeControlAction : SliderActionSo
    {
        private readonly float _minValue = 0.2f;
        private Vector3 initialScale;

        public override void OnSliderValueChanged(float value, GameObject player)
        {
            if (value < _minValue)
            {
                value = _minValue;
            }

            if (initialScale == Vector3.zero)
            {
                initialScale = player.transform.localScale;
            }

            player.transform.localScale = initialScale * value * 2;
        }
    }
}