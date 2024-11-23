using Player;
using Settings;
using Settings.SubSettings;
using UnityEngine;
using UnityEngine.UI;

public class TempSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject Player;
    public SliderActionSo frameSliderAction;

    public void Start()
    {
        GameObject _player = FindAnyObjectByType<PlayerController>().gameObject;
        Player = _player;
        slider.onValueChanged.AddListener(value =>
        {
            frameSliderAction.OnSliderValueChanged(value, Player);
        });
    }
}
