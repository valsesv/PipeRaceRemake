using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Managers.GameScene;
using Zenject;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class GameOverPanel : UiPanel
    {
        [SerializeField] private GameObject _failedTitle;
        [SerializeField] private GameObject _completeTitle;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button homeButton;

        [Inject] private LevelManager _levelManager;
        [Inject] private GameSceneManager _gameSceneManager;

        protected override void Start()
        {
            base.Start();
            homeButton.onClick.AddListener(LoadHomeScene);
            restartButton.onClick.AddListener(RestartLevel);
            nextButton.onClick.AddListener(NextLevel);
        }

        private void OnDestroy()
        {
            homeButton.onClick.RemoveListener(LoadHomeScene);
            restartButton.onClick.RemoveListener(RestartLevel);
            nextButton.onClick.RemoveListener(NextLevel);
        }

        public override void OpenPanel()
        {
            base.OpenPanel();
            GameSceneManager.PauseGameByUIWindow(true);
            _completeTitle.SetActive(_gameSceneManager.IsWin);
            _failedTitle.SetActive(_gameSceneManager.IsWin == false);
            var isNextLevelAvailable = _gameSceneManager.IsWin && _levelManager.CurrentLevelIndex + 1 <= _levelManager.LevelCount;
            nextButton.gameObject.SetActive(isNextLevelAvailable);
        }

        private void RestartLevel()
        {
            _levelManager.RestartLevel();
        }

        private void NextLevel()
        {
            _levelManager.NextLevel();
        }

        private void LoadHomeScene()
        {
            _levelManager.FinishLevel();
        }
    }
}