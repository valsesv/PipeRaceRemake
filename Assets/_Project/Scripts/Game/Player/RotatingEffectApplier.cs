using DG.Tweening;
using UnityEngine;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class RotatingEffectApplier : MonoBehaviour
    {
        [Inject] private EffectsManager _effectsManager;

        private Tween _rotationTween;

        private void Update()
        {
            if (_effectsManager.IsRotating180 && _rotationTween == null)
            {
                ApplyRotatingEffect();
            }
        }

        private void ApplyRotatingEffect()
        {
            _rotationTween = transform.DORotate(new Vector3(0, 0, 180), _effectsManager.RotationDuration, RotateMode.LocalAxisAdd).OnComplete(() =>
            {
                _effectsManager.CompleteRotating();
                _rotationTween = null;
            });
            _rotationTween.Play();
        }
    }
}