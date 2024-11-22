using UnityEngine;

namespace Settings
{
    public class Setting : MonoBehaviour
    {
        public GameObject SettingPanel;
        private enum UIState
        {
            Open,
            Close
        }
        private UIState _currentState = UIState.Close;
        private static Setting _instance;

        private void Awake()
        {
            if(_instance != null && _instance != this)
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
            SettingPanel.SetActive(_currentState == UIState.Open);
        }
    }
}
