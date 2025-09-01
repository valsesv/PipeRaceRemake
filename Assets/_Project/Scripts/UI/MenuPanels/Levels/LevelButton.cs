using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace valsesv._Project.Scripts.UI.MenuPanels
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _levelText;
        public Button Button => _button;
        public int _levelIndex { get; private set; }

        public void Init(int levelIndex, string levelText)
        {
            _levelText.text = levelText;
            _levelIndex = levelIndex;
        }
    }
}