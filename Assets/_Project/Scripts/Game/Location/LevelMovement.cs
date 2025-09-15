using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class LevelMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 _motionSpeed;
        [Inject] private ProjectStateController _gameStateController;
        [Inject] private EffectsManager _effectsManager;

        private void Update()
        {
            if (_gameStateController.State != ProjectState.Game)
            {
                return;
            }

            if (_effectsManager.IsRotating180)
            {
                return;
            }

            var moveAmount = _motionSpeed * Time.deltaTime * _effectsManager.SpeedMultiplier;
            transform.Translate(moveAmount);
        }
    }
}