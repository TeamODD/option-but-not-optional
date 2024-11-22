using UnityEngine;

namespace Settings
{
    public class Setting : MonoBehaviour
    {
        private static Setting _instance;
        public GameObject settingPanel;

        private UIState _currentState = UIState.Close;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ToggleSettingPanel()
        {
            _currentState = _currentState == UIState.Open ? UIState.Close : UIState.Open;
            settingPanel.SetActive(_currentState == UIState.Open);
        }

        private enum UIState
        {
            Open,
            Close
        }
    }
}