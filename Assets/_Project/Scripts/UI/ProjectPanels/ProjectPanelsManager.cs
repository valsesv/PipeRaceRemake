using UnityEngine;
using valsesv._Project.Scripts.Interfaces;

namespace valsesv._Project.Scripts.UI.ProjectPanels
{
    public class ProjectPanelsManager : MonoBehaviour, IManager
    {
        [SerializeField] private ProjectPanelType projectPanelType;
        [SerializeField] private UiPanel[] panels;
        [SerializeField] private ConfirmPanel confirmPanel;

        public ConfirmPanel ConfirmPanel => confirmPanel;

        public void Init(){}

        public void OpenPanel(ProjectPanelType targetPanel) => panels[(int) targetPanel].OpenPanel();
    }
}