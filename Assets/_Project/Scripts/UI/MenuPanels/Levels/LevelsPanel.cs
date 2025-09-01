using System.Collections.Generic;
using UnityEngine;
using valsesv._Project.Scripts.Managers.GameScene;
using Zenject;

namespace valsesv._Project.Scripts.UI.MenuPanels
{
    public class LevelsPanel : UiPanel
    {
        [SerializeField] private Transform _levelsParent;
        [SerializeField] private LevelButton _levelButton;

        [Inject] private LevelManager _levelManager;

        private List<LevelButton> _levelButtons = new();

        protected override void Start()
        {
            base.Start();
            InitLevels();
        }

        private void OnDestroy()
        {
            foreach (var levelButton in _levelButtons)
            {
                levelButton.Button.onClick.RemoveAllListeners();
            }
        }

        private void InitLevels()
        {
            for (int i = 1; i <= _levelManager.LevelCount; i++)
            {
                var levelButton = Instantiate(_levelButton, _levelsParent);
                InitLevelButton(levelButton, i);
            }
        }

        private void InitLevelButton(LevelButton levelButton, int levelIndex)
        {
            _levelButtons.Add(levelButton);
            levelButton.Init(levelIndex, levelIndex.ToString());
                
            levelButton.Button.onClick.AddListener(() =>
                {
                    _levelManager.StartLevel(levelIndex);
                }
            );
        }
    }
}