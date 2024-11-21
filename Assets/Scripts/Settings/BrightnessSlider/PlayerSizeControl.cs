using UnityEngine;



namespace Settings.BrightnessSlider
{
    public class PlayerSizeControl : BrightnessSliderAction
    {
        public GameObject player; 
        private Vector3 originScale; 
        
        private const float MinScaleMultiplier = 0.5f;
        private const float MaxScaleMultiplier = 2.0f; 

        private void Start()
        {
            if (player != null)
                originScale = player.transform.localScale;
            else
                Debug.LogWarning("Player object is not assigned in PlayerSizeControl.");
        }
        
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            if (player == null) return;
            
            var normalizedValue = Mathf.InverseLerp(0, 100, value); 
            
            var scaleMultiplier = Mathf.Lerp(MinScaleMultiplier, MaxScaleMultiplier, normalizedValue);
            
            player.transform.localScale = originScale * scaleMultiplier;

            Debug.Log($"Player size adjusted. Scale: {player.transform.localScale}, Slider Value: {value}");
        }
    }
}