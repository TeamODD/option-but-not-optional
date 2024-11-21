using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ResolutionSliderAction", menuName = "ResolutionSliderAction")]
    public class ResolutionSliderAction : ScriptableObject
    {
        public Slider slider;
    }
}