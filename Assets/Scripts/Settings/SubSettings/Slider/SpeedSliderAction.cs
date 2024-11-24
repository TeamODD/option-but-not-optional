using Player;
using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "SpeedSliderAction", menuName = "SpeedSliderAction")]
    //속도 빨라지는 슬라이더 액션 
    public class SpeedSliderAction : SliderActionSo
    {
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            player.GetComponent<PlayerController>().ChangeMovePower(value);
        }
    }
}