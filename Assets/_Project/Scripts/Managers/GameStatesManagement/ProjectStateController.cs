using System;
using UnityEngine;
using valsesv._Project.Scripts.Interfaces;
using valsesv._Project.Scripts.Managers.ScenesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameStatesManagement
{
    public class ProjectStateController : MonoBehaviour, IManager
    {
        private ProjectState _state;

        [Inject] private SceneController _sceneController;

        public event Action<ProjectState> OnStateChangedEvent;
        public event Action OnMenuStateEvent;
        public event Action OnGameStartedEvent;

        public bool IsPlaying { get; private set; }

        public ProjectState State
        {
            get => _state;
            private set
            {
                if (value == _state)
                {
                    return;
                }
                _state = value;
                switch(_state)
                {
                    case ProjectState.Menu:
                        SetMenuState();
                        break;
                    case ProjectState.Game:
                        SetGameState();
                        break;
                    case ProjectState.Boot:
                        LoadBootScene();
                        break;
                    case ProjectState.None:
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                OnStateChangedEvent?.Invoke(_state);
            }
        }

        public void Init(){ }

        public void SetState(ProjectState projectState)
        {
            State = projectState;
        }

        private void LoadBootScene()
        {
            SetState(ProjectState.Menu);
            _sceneController.LoadScene(SceneType.Menu);
        }

        private void SetMenuState()
        {
            IsPlaying = false;
            OnMenuStateEvent?.Invoke();
        }

        private void SetGameState()
        {
            if (IsPlaying) return;
            
            IsPlaying = true;
            OnGameStartedEvent?.Invoke();
        }
    }
}