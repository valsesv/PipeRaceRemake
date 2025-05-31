using UnityEngine;
using valsesv._Project.Scripts.Managers.GameScene;
using valsesv._Project.Scripts.UI.GamePanels;
using Zenject;

namespace valsesv._Project.Scripts.Resources
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSceneManager gameSceneManager;
        [SerializeField] private GamePanelsManager gamePanelsManager;

        public override void InstallBindings()
        {
            Container.Bind<GameSceneManager>().FromInstance(gameSceneManager).AsSingle();
            Container.Bind<GamePanelsManager>().FromInstance(gamePanelsManager).AsSingle();
        }
    }
}