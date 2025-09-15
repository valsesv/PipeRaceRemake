using UnityEngine;
using valsesv._Project.Scripts.Game;
using valsesv._Project.Scripts.Managers.GameScene;
using valsesv._Project.Scripts.UI.GamePanels;
using Zenject;

namespace valsesv._Project.Scripts.Resources
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSceneManager gameSceneManager;
        [SerializeField] private GamePanelsManager gamePanelsManager;
        [SerializeField] private MenuPanelsManager menuPanelsManager;
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private LevelMovement levelMovement;
        [SerializeField] private Player player;
        [SerializeField] private EffectsManager effectsManager;

        public override void InstallBindings()
        {
            Container.Bind<GameSceneManager>().FromInstance(gameSceneManager).AsSingle();
            Container.Bind<GamePanelsManager>().FromInstance(gamePanelsManager).AsSingle();
            Container.Bind<MenuPanelsManager>().FromInstance(menuPanelsManager).AsSingle();
            Container.Bind<LevelManager>().FromInstance(levelManager).AsSingle();
            Container.Bind<LevelMovement>().FromInstance(levelMovement).AsSingle();
            Container.Bind<Player>().FromInstance(player).AsSingle();
            Container.Bind<EffectsManager>().FromInstance(effectsManager).AsSingle();
        }
    }
}