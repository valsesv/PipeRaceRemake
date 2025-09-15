using System.Collections.Generic;
using UnityEngine;
using valsesv._Project.Scripts.Game.Obstacles;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class EffectsManager : MonoBehaviour
    {
        public float InverseControl { get; private set; } = 1f;
        public float SpeedMultiplier { get; private set; } = 1f;
        public float RotationDuration { get; private set; }
        public bool IsRotating180 { get; private set; }
        public float _inversionControlTimer {get; private set;}
        public float _speedUpTimer {get; private set;}

        public List<GameEffectType> Effects { get; private set; } = new List<GameEffectType>();

        [Inject] private ProjectStateController _gameStateController;

        private void OnEnable()
        {
            _gameStateController.OnStateChangedEvent += OnStateChanged;
        }

        private void OnDisable()
        {
            _gameStateController.OnStateChangedEvent -= OnStateChanged;
        }

        private void OnStateChanged(ProjectState state)
        {
            if (state == ProjectState.Menu)
            {
                ResetEffects();
            }
        }

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

        private void ResetEffects()
        {
            Effects.Clear();
            InverseControl = 1;
            SpeedMultiplier = 1;
            IsRotating180 = false;
            RotationDuration = 0;
        }
    }
}