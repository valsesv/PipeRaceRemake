using UnityEngine;
using valsesv._Project.Scripts.Managers.SoundManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public abstract class GameEffect : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private AudioClip _effectSound;

        public GameEffectType _effectType { get; protected set; }

        [Inject] private SoundManager _soundManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var player) == false)
            {
                return;
            }

            ApplyEffect();
        }

        protected virtual void ApplyEffect()
        {
            _soundManager.PlaySound(_effectSound);
        }
    }
}