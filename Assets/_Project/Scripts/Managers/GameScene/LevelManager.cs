using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameScene
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _levels;

        [Inject] private ProjectStateController _projectStateController;

        public int LevelCount => _levels.Length;

        public void StartLevel(int levelIndex)
        {
            _projectStateController.SetState(ProjectState.Game);
            var targetLevel = _levels[levelIndex];
            Instantiate(targetLevel);
        }
    }
}