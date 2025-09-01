using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class MenuPanelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private MenuPanelType menuPanelType;

        [Inject] private MenuPanelsManager _menuPanelsManager;

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                _menuPanelsManager.OpenPanel(menuPanelType);
            });
        }
    }
}