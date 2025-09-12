using UnityEngine;
using valsesv._Project.Scripts.Game;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameScene
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _levels;

        [Inject] private ProjectStateController _projectStateController;
        [Inject] private LevelMovement _levelMovement;

        public int LevelCount => _levels.Length;
        public int _currentLevelIndex { get; private set; }

        private GameObject _currentLevel;

        public void StartLevel(int levelIndex)
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }
            _currentLevelIndex = levelIndex;
            _projectStateController.SetState(ProjectState.Game);
            var targetLevel = _levels[levelIndex];
            _currentLevel = Instantiate(targetLevel);
            _currentLevel.transform.SetParent(_levelMovement.transform);
            _currentLevel.transform.localRotation = Quaternion.Euler(Vector3.zero);
            GameSceneManager.PauseGameByUIWindow(false);
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
    }
}