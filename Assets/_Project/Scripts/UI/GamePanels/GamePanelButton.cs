using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace valsesv._Project.Scripts.UI.GamePanels
{
    public class GamePanelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private GamePanelType gamePanelType;

        [Inject] private GamePanelsManager _gamePanelsManager;

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                _gamePanelsManager.OpenPanel(gamePanelType);
            });
        }
    }
}