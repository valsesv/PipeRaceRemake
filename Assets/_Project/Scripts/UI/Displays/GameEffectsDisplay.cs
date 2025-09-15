
using TMPro;
using UnityEngine;
using valsesv._Project.Scripts.Game;
using Zenject;

namespace valsesv._Project.Scripts.UI.Displays
{
    public class GameEffectsDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _speedUpEffect;
        [SerializeField] private TextMeshProUGUI _speedUpDurationLeft;
        [SerializeField] private GameObject _rotationEffect;
        [SerializeField] private GameObject _inversionEffect;
        [SerializeField] private TextMeshProUGUI _inversControlDurationLeft;
        [SerializeField] private GameObject _changeSkinEffect;
        [SerializeField] private TextMeshProUGUI _changeSkinDurationLeft;


        [Inject] private EffectsManager _effectsManager;

        private void Start()
        {
            _speedUpEffect.SetActive(false);
            _rotationEffect.SetActive(false);
            _inversionEffect.SetActive(false);
        }

        private void Update()
        {
            UpdateEffect(_speedUpEffect, _effectsManager._speedUpTimer, _speedUpDurationLeft);
            _rotationEffect.SetActive(_effectsManager.IsRotating180);
            UpdateEffect(_inversionEffect, _effectsManager._inversionControlTimer, _inversControlDurationLeft);
            UpdateEffect(_changeSkinEffect, _effectsManager._changeSkinTimer, _changeSkinDurationLeft);
        }

        private void UpdateEffect(GameObject effect, float durationLeft, TextMeshProUGUI durationLeftText = null)
        {
            var isActive = durationLeft > 0;
            if (effect.activeSelf == false && isActive)
            {
                effect.transform.SetAsLastSibling();
            }
            effect.SetActive(isActive);
            if (durationLeftText == null)
            {
                return;
            }
            durationLeftText.text = durationLeft.ToString("F1");
        }
    }
}