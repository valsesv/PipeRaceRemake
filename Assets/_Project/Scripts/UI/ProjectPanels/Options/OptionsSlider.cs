using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Managers.GameConfiguration;
using valsesv._Project.Scripts.Managers.SoundManagement;
using Zenject;

namespace valsesv._Project.Scripts.UI.Options
{
    public class OptionsSlider : MonoBehaviour
    {
        [SerializeField] private ConfigKey sliderType;
        [SerializeField] private Slider itemSlider;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private float baseValue = 0.5f;
        [SerializeField] private Vector2 valueRange = new(0f, 100f);

        private float _sliderValue;
        private float GetActualValue
        {
            get
            {
                switch (sliderType)
                {
                    case ConfigKey.GameSound:
                    case ConfigKey.GameMusic:
                        return Mathf.Lerp(valueRange.x, valueRange.y, _sliderValue);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [Inject] private SoundManager _soundManager;
        [Inject] private MusicManager _musicManager;

        public void Init()
        {
            itemSlider.onValueChanged.AddListener(ChangeSliderValue);
            SetStartValue();
        }

        private void ChangeSliderValue(float targetValue)
        {
            ConfigManager.SetValue(sliderType, targetValue);
            UpdateValue(targetValue);
        }

        private void UpdateValue(float targetValue)
        {
            _sliderValue = targetValue;
            UpdateValueDisplay();

            switch (sliderType)
            {
                case ConfigKey.GameSound:
                    _soundManager.SetVolume(_sliderValue);
                    break;
                case ConfigKey.GameMusic:
                    _musicManager.SetVolume(_sliderValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateValueDisplay()
        {
            valueText.text = $"{GetActualValue:F0}";
        }

        private void SetStartValue()
        {
            var targetValue = ConfigManager.GetValue(sliderType, baseValue);
            itemSlider.value = targetValue;
        }
    }
}