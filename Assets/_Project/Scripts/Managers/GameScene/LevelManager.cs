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

        public void StartLevel(int levelIndex)
        {
            _projectStateController.SetState(ProjectState.Game);
            var targetLevel = _levels[levelIndex];
            var level = Instantiate(targetLevel);
            level.transform.SetParent(_levelMovement.transform);
            level.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}