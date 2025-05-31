using UnityEngine;

namespace valsesv._Project.Scripts.Managers.GameConfiguration
{
    public static class ConfigManager
    {
        public static float GetValue(ConfigKey targetKey, float baseValue)
        {
            var keyToString = GetKey(targetKey);
            return PlayerPrefs.HasKey(keyToString) ? PlayerPrefs.GetFloat(keyToString) : baseValue;
        }

        public static void SetValue(ConfigKey targetKey, float targetValue)
        {
            var keyToString = GetKey(targetKey);
            PlayerPrefs.SetFloat(keyToString, targetValue);
        }

        private static string GetKey(ConfigKey targetKey) => targetKey.ToString();
    }
}