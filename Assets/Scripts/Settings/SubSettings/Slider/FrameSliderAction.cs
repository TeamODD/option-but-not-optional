using System.Collections.Generic;
using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "FrameSliderAction", menuName = "FrameSliderAction")]
    public class FrameSliderAction : SliderActionSo
    {
        private List<GameObject> bullet;

        public override void OnSliderValueChanged(float value, GameObject player)
        {
            var bullets = FindObjectsByType<FrameRateBullet>(FindObjectsSortMode.None);
            bullet = new List<GameObject>();

            foreach (var item in bullets)
            {
                bullet.Add(item.gameObject);
            }

            for (var i = 0; i < bullet.Count; i++)
            {
                bullet[i].GetComponent<FrameRateBullet>().ChangeMovePower(value);
            }
        }
    }
}