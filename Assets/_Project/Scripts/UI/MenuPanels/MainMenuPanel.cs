using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.UI.MenuPanels
{
    public class MainMenuPanel : UiPanel
    {
        [SerializeField] private Button playButton;

        [Inject] private ProjectStateController _projectStateController;

        protected override void Start()
        {
            base.Start();
            playButton.onClick.AddListener(() =>
            {
                _projectStateController.SetState(ProjectState.Game);
            });
        }
    }
}