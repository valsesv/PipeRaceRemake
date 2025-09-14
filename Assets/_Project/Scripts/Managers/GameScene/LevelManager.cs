using UnityEngine;
using valsesv._Project.Scripts.Game;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using valsesv._Project.Scripts.Managers.SoundManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameScene
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _levels;
        [SerializeField] private AudioClip _levelSound;
        [SerializeField] private AudioClip _endlessLevelSound;

        [Inject] private ProjectStateController _projectStateController;
        [Inject] private LevelMovement _levelMovement;
        [Inject] private SoundManager _soundManager;
        [Inject] private DiContainer _container;

        public int LevelCount => _levels.Length;
        public int _currentLevelIndex { get; private set; }

        private GameObject _currentLevel;

        public void FinishLevel()
        {
            UnloadLevel();
            _projectStateController.SetState(ProjectState.Menu);
        }

        public void StartLevel(int levelIndex)
        {
            UnloadLevel();
            _currentLevelIndex = levelIndex;
            _projectStateController.SetState(ProjectState.Game);
            var targetLevel = _levels[levelIndex];
            _currentLevel = _container.InstantiatePrefab(targetLevel);
            _currentLevel.transform.SetParent(_levelMovement.transform);
            _currentLevel.transform.localRotation = Quaternion.Euler(Vector3.zero);
            PLayStartLevelMusic();
        }

        public void RestartLevel()
        {
            StartLevel(_currentLevelIndex);
        }

        public void NextLevel()
        {
            if (_currentLevelIndex >= LevelCount)
            {
                Debug.LogError("No next level");
                return;
            }

            StartLevel(_currentLevelIndex + 1);
        }

        private void UnloadLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }
            GameSceneManager.PauseGameByUIWindow(false);
        }

        private void PLayStartLevelMusic()
        {
            switch (_currentLevelIndex)
            {
                case -1:
                    _soundManager.PlaySound(_endlessLevelSound);
                    break;
                default:
                    _soundManager.PlaySound(_levelSound);
                    break;
            }
        }
    }
}