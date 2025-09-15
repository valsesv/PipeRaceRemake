using UnityEngine;
using Zenject;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class ObjectRotation : MonoBehaviour
    {
        private float _rotationSpeed = 45f;

        [Inject] private EffectsManager _effectsManager;

        private void Update()
        {
            if (_effectsManager.IsRotating180)
            {
                return;
            }

            var rotationAmount = new Vector3(0, 0, _rotationSpeed) * Time.deltaTime * _effectsManager.SpeedMultiplier;
            transform.Rotate(rotationAmount);
        }
    }
}
