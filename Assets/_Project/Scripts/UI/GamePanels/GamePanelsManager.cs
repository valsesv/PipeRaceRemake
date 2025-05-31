using UnityEngine;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class GamePanelsManager : MonoBehaviour
    {
        [SerializeField] private GamePanelType gamePanelType;
        [SerializeField] private UiPanel[] panels;

        public void OpenPanel(GamePanelType targetPanel)
        {
            panels[(int)targetPanel].OpenPanel();
        }
    }
}