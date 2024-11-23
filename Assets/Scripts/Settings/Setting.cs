using UnityEngine;

namespace Settings
{
    public class Setting : MonoBehaviour
    {
        private static Setting _instance;
        public GameObject settingPanel;

        [SerializeField] private GameObject graphicBox;

        [SerializeField] private GameObject soundBox;

        [SerializeField] private GameObject systemBox;

        private SettingType _currentSettingType = SettingType.Graphic;

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

        public void ChangeSettingType(int type)
        {
            _currentSettingType = (SettingType)type;
            graphicBox.SetActive(_currentSettingType == SettingType.Graphic);
            soundBox.SetActive(_currentSettingType == SettingType.Sound);
            systemBox.SetActive(_currentSettingType == SettingType.System);
        }

        private enum SettingType
        {
            Graphic,
            Sound,
            System
        }

        private enum UIState
        {
            Open,
            Close
        }
    }
}