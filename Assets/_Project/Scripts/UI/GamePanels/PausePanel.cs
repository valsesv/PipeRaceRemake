using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Managers.GameScene;
using valsesv._Project.Scripts.UI.ProjectPanels;
using Zenject;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class PausePanel : UiPanel
    {
        [SerializeField] private Button giveUpButton;

        [Inject] private GameSceneManager _gameSceneManager;
        [Inject] private ProjectPanelsManager _projectPanelsManager;

        protected override void Start()
        {
            base.Start();
            giveUpButton.onClick.AddListener(FinishGame);
        }

        public override void OpenPanel()
        {
            base.OpenPanel();
            GameSceneManager.PauseGameByUIWindow(true);
        }

        public override void CloseWindow()
        {
            base.CloseWindow();
            GameSceneManager.PauseGameByUIWindow(false);
        }

        private void FinishGame()
        {
            _projectPanelsManager.ConfirmPanel.OnConfirmed += () =>
            {
                base.CloseWindow();
                _gameSceneManager.FinishGameInstantly();
            };
            _projectPanelsManager.ConfirmPanel.OpenPanel();
        }
    }
}