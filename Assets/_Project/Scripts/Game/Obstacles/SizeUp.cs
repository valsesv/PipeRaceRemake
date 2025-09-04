using DG.Tweening;
using UnityEngine;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class SizeUp : MonoBehaviour
    {
        [SerializeField] private float _scaleUpDistance = 35;
        [SerializeField] private float _scaleUpDuration = 0.5f;
        private bool _isAnimated;
        private Vector3 targetScale;

        private void Start()
        {
            targetScale = transform.localScale;
            transform.localScale = Vector3.zero;
        }

        private void Update()
        {
            if (_isAnimated)
            {
                return;
            }
            if (transform.position.z > _scaleUpDistance)
            {
                return;
            }
            transform.DOScale(targetScale, _scaleUpDuration);
            _isAnimated = true;
        }
    }
}
