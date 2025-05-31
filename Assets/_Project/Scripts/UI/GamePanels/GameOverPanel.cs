using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class GameOverPanel : UiPanel
    {
        [SerializeField] private Button homeButton;

        [Inject] private ProjectStateController _projectStateController;

        protected override void Start()
        {
            base.Start();
            homeButton.onClick.AddListener(LoadHomeScene);
        }

        private void LoadHomeScene()
        {
            _projectStateController.SetState(ProjectState.Menu);
        }
    }
}