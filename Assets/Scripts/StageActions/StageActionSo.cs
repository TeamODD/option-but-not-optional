using Settings;
using UnityEngine;

namespace StageActions
{
    [CreateAssetMenu(fileName = "NewStageAction", menuName = "StageActions/StageAction", order = 0)]
    public class StageActionSo : ScriptableObject
    {
        public SliderActionSo[] sliderActions = new SliderActionSo[6];
        public ToggleActionSo[] toggleActions = new ToggleActionSo[3];
    }
}