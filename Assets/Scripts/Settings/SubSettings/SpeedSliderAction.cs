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
            // if (value < 0.5f)
            // {
            //     Debug.Log("Player의 움직임이 감소한다.");
            // }
            // else
            // {
            //     Debug.Log("Player의 움직임이 증가한다.");
            // }
            player.GetComponent<PlayerController>().ChangeMovePower(value);
            //플레이어의 속도를 조절한다.
        }
    }
}