using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.UI.ProjectPanels;
using Zenject;

namespace valsesv._Project.Scripts.UI.Buttons
{
    public class ProjectPanelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ProjectPanelType projectPanelType;

        [Inject] private ProjectPanelsManager _projectPanelsManager;

        private void Start()
        {
            button.onClick.AddListener(OpenPanel);
        }

        private void OpenPanel()
        {
            _projectPanelsManager.OpenPanel(projectPanelType);
        }
    }
}