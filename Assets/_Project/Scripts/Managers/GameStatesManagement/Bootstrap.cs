using UnityEngine;
using valsesv._Project.Scripts.Resources;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameStatesManagement
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private ProjectInstaller _projectInstaller;
        [Inject] private ProjectStateController _projectStateController;

        private void Awake()
        {
            _projectInstaller.InitManagers();
            _projectStateController.SetState(ProjectState.Boot);
        }
    }
}