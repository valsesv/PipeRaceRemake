using UnityEngine;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class SkinEffectApplier : MonoBehaviour
    {
        [SerializeField] private Material _pipeMaterial;
        [SerializeField] private Texture defaultPipeTexture;
        [SerializeField] private Texture changedPipeTexture;
        [Header("")]
        [SerializeField] private Material _obstacleMaterial;
        [SerializeField] private Color defaultObstacleColor;
        [SerializeField] private Color changedObstacleColor;

        [Inject] private EffectsManager _effectsManager;

        private Texture _currentTexture;

        private void Start()
        {
            _currentTexture = defaultPipeTexture;
            _pipeMaterial.SetTexture("_MainTex", defaultPipeTexture);
            _obstacleMaterial.SetColor("_Color", defaultObstacleColor);
        }

        private void OnDestroy()
        {
            _pipeMaterial.SetTexture("_MainTex", defaultPipeTexture);
            _obstacleMaterial.SetColor("_Color", defaultObstacleColor);
        }

        private void Update()
        {
            SetTexture(_effectsManager._changeSkinTimer > 0);
        }

        private void SetTexture(bool isChanged)
        {
            Texture targetPipeTexture = isChanged ? changedPipeTexture : defaultPipeTexture;
            Color targetObstacleTexture = isChanged ? changedObstacleColor : defaultObstacleColor;

            if (targetPipeTexture == _currentTexture)
            {
                return;
            }

            _currentTexture = targetPipeTexture;
            _pipeMaterial.SetTexture("_MainTex", targetPipeTexture);
            _obstacleMaterial.SetColor("_Color", targetObstacleTexture);
        }
    }
}