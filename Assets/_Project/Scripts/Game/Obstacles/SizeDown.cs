using DG.Tweening;
using UnityEngine;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class SizeDown : MonoBehaviour
    {
        [SerializeField] private float _scaleUpDistance = 20;
        [SerializeField] private float _ScaleDownDuration = 0.5f;
        private bool _isAnimated;

        private void Update()
        {
            if (_isAnimated)
            {
                return;
            }
            if (transform.position.z < _scaleUpDistance)
            {
                return;
            }
            transform.DOScale(Vector3.zero, _ScaleDownDuration);
            _isAnimated = true;
        }
    }
}
