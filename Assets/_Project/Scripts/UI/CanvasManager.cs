using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _menuCanvasGroup;
        [SerializeField] private CanvasGroup _gameCanvasGroup;

        [Inject] private ProjectStateController _projectStateController;

        private void OnEnable()
        {
            _projectStateController.OnStateChangedEvent += OnStateChanged;
        }

        private void OnDisable()
        {
            _projectStateController.OnStateChangedEvent -= OnStateChanged;
        }

        private void OnStateChanged(ProjectState state)
        {
            CanvasSwapper.CanvasGroupSwap(_menuCanvasGroup, state == ProjectState.Menu);
            CanvasSwapper.CanvasGroupSwap(_gameCanvasGroup, state == ProjectState.Game);
        }
    }
}