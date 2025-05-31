using DG.Tweening;
using UnityEngine;

namespace valsesv._Project.Scripts.Helpers
{
    public class BlinkingMaterial : MonoBehaviour
    {
        [SerializeField] private Material transparentMaterial;

        [SerializeField, Range(0f, 1f)] private float maxAlpha = 1f;
        [SerializeField, Range(0f, 1f)] private float minAlpha = 0.5f;
        [SerializeField] private float blinkDuration = 0.5f;

        public Material TransparentMaterial => transparentMaterial;

        private Tween _blinkTween;

        private void Start()
        {
            Blink();
        }

        private void Blink()
        {
            var startColor = transparentMaterial.color;
            startColor.a = maxAlpha;
            transparentMaterial.color = startColor;

            _blinkTween = transparentMaterial.DOFade(minAlpha, blinkDuration).SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void StopBlink()
        {
            _blinkTween.Kill();
        }
    }
}