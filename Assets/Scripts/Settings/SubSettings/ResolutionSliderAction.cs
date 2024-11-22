using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "ResolutionSliderAction", menuName = "ResolutionSliderAction")]
    public class ResolutionSliderAction : SliderActionSo
    {
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            if (value < 0.7f)
            {
                Debug.Log("Resolution is under 0.7f : " + value);
                
            }
        }
    }
}