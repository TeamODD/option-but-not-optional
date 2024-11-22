using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class ToggleController : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private GameObject player;
        private ToggleActionSo action;

        private void Start()
        {
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        public void SetAction(ToggleActionSo newAction)
        {
            action = newAction;
            if (action == null)
            {
                Debug.LogWarning("No action set for this toggle : SetAction");
            }
        }

        private void OnToggleValueChanged(bool value)
        {
            if (action != null)
            {
                action.OnToggleValueChanged(value, player);
            }
            else
            {
                Debug.LogWarning("No action set for this toggle : OnToggleValueChanged");
            }
        }
    }
}