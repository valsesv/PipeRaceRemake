using UnityEngine;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class MenuPanelsManager : MonoBehaviour
    {
        [SerializeField] private MenuPanelType gamePanelType;
        [SerializeField] private UiPanel[] panels;

        public void OpenPanel(MenuPanelType targetPanel)
        {
            panels[(int)targetPanel].OpenPanel();
        }
    }
}