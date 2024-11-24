using System.Collections.Generic;
using Settings;
using UnityEngine;
namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "BrightnessControl", menuName = "BrightnessControl")]
    public class BrightnessControl : SliderActionSo
    {
        private List<GameObject> wall;
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            WallController[] walls = FindObjectsByType<WallController>(FindObjectsSortMode.None);
            wall = new List<GameObject>();

            foreach (var item in walls)
            {
                wall.Add(item.gameObject);
            }

            for (int i = 0; i < wall.Count; i++)
            {
                wall[i].GetComponent<WallController>().ChnageBright(value);
            }
        }
    }
}
