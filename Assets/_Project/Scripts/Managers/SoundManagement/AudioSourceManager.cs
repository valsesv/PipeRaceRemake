using UnityEngine;
using valsesv._Project.Scripts.Interfaces;
using valsesv._Project.Scripts.Managers.GameConfiguration;

namespace valsesv._Project.Scripts.Managers.SoundManagement
{
    public abstract class AudioSourceManager : MonoBehaviour, IManager, ISwitchable
    {
        [SerializeField] protected AudioSource soundSource;
        [SerializeField] private float baseValue = 0.5f;

        private float _value;
        protected ConfigKey ValueConfigKey;
        protected ConfigKey SwitchConfigKey;

        public bool IsOn { get; private set; }

        public virtual void Switch()
        {
            var targetVolume = IsOn ? _value : 0f;
            soundSource.volume = targetVolume;
        }

        public void SetVolume(float targetValue)
        {
            _value = targetValue;
            soundSource.volume = targetValue;
            ConfigManager.SetValue(ValueConfigKey, targetValue);
        }

        public virtual void Init()
        {
            IsOn = ConfigManager.GetValue(SwitchConfigKey, 1f) > 0;
            SetVolume(ConfigManager.GetValue(ValueConfigKey, baseValue));
        }
    }
}