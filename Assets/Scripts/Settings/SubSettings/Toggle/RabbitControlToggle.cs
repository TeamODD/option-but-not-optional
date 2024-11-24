using Enemys.Rabbits;
using UnityEngine;

namespace Settings.SubSettings.Toggle
{
    [CreateAssetMenu(fileName = "RabbitControlToggle", menuName = "RabbitControlToggle")]
    public class RabbitControlToggle : ToggleActionSo
    {
        public override void OnToggleValueChanged(bool value, GameObject player)
        {
            if (value)
            {
                BlackRabbit.checkVolume = false;
            }
            else
            {
                BlackRabbit.checkVolume = true;
            }
        }
    }
}