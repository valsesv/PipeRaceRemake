using System;
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
        public int CurrentLevelIndex { get; private set; }

        public GameObject CurrentLevel { get; private set; }

        public event Action OnLevelLoaded;

        public void FinishLevel()
        {
            UnloadLevel();
            _projectStateController.SetState(ProjectState.Menu);
        }

        public void StartLevel(int levelIndex)
        {
            UnloadLevel();
            CurrentLevelIndex = levelIndex;
            _projectStateController.SetState(ProjectState.Game);
            var targetLevel = _levels[levelIndex];
            CurrentLevel = _container.InstantiatePrefab(targetLevel);
            CurrentLevel.transform.SetParent(_levelMovement.transform);
            CurrentLevel.transform.localRotation = Quaternion.Euler(Vector3.zero);
            PLayStartLevelMusic();
            OnLevelLoaded?.Invoke();
        }

        public void RestartLevel()
        {
            StartLevel(CurrentLevelIndex);
        }

        public void NextLevel()
        {
            if (CurrentLevelIndex >= LevelCount)
            {
                Debug.LogError("No next level");
                return;
            }

            StartLevel(CurrentLevelIndex + 1);
        }

        private void UnloadLevel()
        {
            if (CurrentLevel != null)
            {
                Destroy(CurrentLevel);
            }
            GameSceneManager.PauseGameByUIWindow(false);
        }

        private void PLayStartLevelMusic()
        {
            switch (CurrentLevelIndex)
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