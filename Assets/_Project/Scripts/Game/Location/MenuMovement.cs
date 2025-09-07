using DG.Tweening;
using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class MenuMovement : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [Inject] private ProjectStateController _gameStateController;

        private Tween _rotationTween;

        private void OnEnable()
        {
            _gameStateController.OnStateChangedEvent += SetRotation;
            SetRotation(_gameStateController.State);
        }

        private void OnDisable()
        {
            _gameStateController.OnStateChangedEvent -= SetRotation;
        }

        private void SetRotation(ProjectState state)
        {
            _rotationTween?.Kill();
            if (state != ProjectState.Menu)
            {
                return;
            }

            _rotationTween = transform.DORotate(new Vector3(0, 0, 360), _rotationSpeed, RotateMode.FastBeyond360)
                                        .SetLoops(-1, LoopType.Incremental)
                                        .SetEase(Ease.Linear)
                                        .SetSpeedBased(true);
        }
    }
}