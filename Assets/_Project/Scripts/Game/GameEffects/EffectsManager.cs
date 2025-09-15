using System.Collections.Generic;
using UnityEngine;
using valsesv._Project.Scripts.Game.Obstacles;

namespace valsesv._Project.Scripts.Game
{
    public class EffectsManager : MonoBehaviour
    {
        public float InverseControl { get; private set; } = 1f;
        public float SpeedMultiplier { get; private set; } = 1f;
        public float RotationDuration { get; private set; }
        public bool IsRotating180 { get; private set; }
        private float _inversionControlTimer;
        private float _speedUpTimer;

        public List<GameEffectType> Effects { get; private set; } = new List<GameEffectType>();

        private void Update()
        {
            if (Effects.Contains(GameEffectType.InversionControl))
            InversionControlTimer();
            if (Effects.Contains(GameEffectType.SpeedUp))
            SpeedUpTimer();
        }

        public void ApplyEffect(GameEffectType effectType, float duration)
        {
            switch (effectType)
            {
                case GameEffectType.InversionControl:
                    _inversionControlTimer += duration;
                    InverseControl = -1;
                    Effects.Add(GameEffectType.InversionControl);
                    break;
                case GameEffectType.SpeedUp:
                    _speedUpTimer += duration;
                    SpeedMultiplier = 1.5f;
                    Effects.Add(GameEffectType.SpeedUp);
                    break;
                case GameEffectType.Rotate180:
                    IsRotating180 = true;
                    RotationDuration = duration;
                    Effects.Add(GameEffectType.Rotate180);
                    break;
            }
        }

        public void CompleteRotating()
        {
            Effects.Remove(GameEffectType.Rotate180);
            IsRotating180 = false;
            RotationDuration = 0;
        }

        private void InversionControlTimer()
        {
            _inversionControlTimer -= Time.deltaTime;
            if (_inversionControlTimer <= 0)
            {
                Effects.Remove(GameEffectType.InversionControl);
                InverseControl = 1;
            }
        }

        private void SpeedUpTimer()
        {
            _speedUpTimer -= Time.deltaTime;
            if (_speedUpTimer <= 0)
            {
                Effects.Remove(GameEffectType.SpeedUp);
                SpeedMultiplier = 1;
            }
        }
    }
}