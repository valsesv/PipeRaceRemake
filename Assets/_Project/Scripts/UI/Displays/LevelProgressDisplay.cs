using TMPro;
using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Game;
using valsesv._Project.Scripts.Managers.GameScene;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.UI.Displays
{
    public class LevelProgressDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private float _deltaDistance = -0.2f; // distance off collision, so that slider goes to 1 in the end

        [Inject] private Player _player;
        [Inject] private LevelManager _levelManager;
        [Inject] private ProjectStateController _projectStateController;

        private float _startDistance;
        private Transform _finishObject;

        void OnEnable()
        {
            _slider.gameObject.SetActive(false);
            _levelManager.OnLevelLoaded += OnLevelLoaded;
            _projectStateController.OnStateChangedEvent += OnStateChanged;
        }

        void OnDisable()
        {
            _levelManager.OnLevelLoaded -= OnLevelLoaded;
            _projectStateController.OnStateChangedEvent -= OnStateChanged;
        }

        private void OnStateChanged(ProjectState state)
        {
            _slider.gameObject.SetActive(state == ProjectState.Game);
        }

        private void OnLevelLoaded()
        {
            if (_levelManager.CurrentLevelIndex == -1)
            {
                return;
            }
            _levelText.text = $"Level {_levelManager.CurrentLevelIndex}";
            _finishObject = _levelManager.CurrentLevel.GetComponentInChildren<LevelEnd>().transform;
            _startDistance = GetCurrentDistance();
            _slider.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_slider.gameObject.activeSelf == false)
            {
                return;
            }

            if (_projectStateController.State != ProjectState.Game)
            {
                return;
            }

            UpdateSlider();
        }

        private void UpdateSlider()
        {
            var currentDistance = GetCurrentDistance();
            _slider.value = 1f - (currentDistance / _startDistance);
        }

        private float GetCurrentDistance()
        {
            return _finishObject.transform.position.z - _player.transform.position.z + _deltaDistance;
        }
    }
}