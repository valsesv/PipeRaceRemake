using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using valsesv._Project.Scripts.Managers.MoneyManagement;
using valsesv._Project.Scripts.Managers.SaveManagement;
using valsesv._Project.Scripts.Managers.ScenesManagement;
using valsesv._Project.Scripts.Managers.SoundManagement;
using valsesv._Project.Scripts.UI.ProjectPanels;
using Zenject;

namespace valsesv._Project.Scripts.Resources
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ProjectStateController projectStateController;
        [SerializeField] private SceneController sceneController;
        [Space(10)]
        [SerializeField] private SaveManager saveManager;
        [SerializeField] private MoneyWallet moneyWallet;
        [Space(10)]
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private MusicManager musicManager;
        [Space(10)]
        [SerializeField] private ProjectPanelsManager projectPanelsManager;

        private ProjectInstaller _projectInstaller;

        public override void InstallBindings()
        {
            BindManagers();
            BindSound();
        }

        public void InitManagers()
        {
            projectStateController.Init();
            sceneController.Init();
            projectPanelsManager.Init();
            saveManager.Init();
            // money init should be after saveManager, cause it's taking value from save
            moneyWallet.Init();

            soundManager.Init();
            musicManager.Init();
        }

        private void BindManagers()
        {
            Container.Bind<ProjectInstaller>().FromInstance(this).AsSingle();

            Container.Bind<SaveManager>().FromInstance(saveManager).AsSingle();
            Container.Bind<MoneyWallet>().FromInstance(moneyWallet).AsSingle();

            Container.Bind<ProjectStateController>().FromInstance(projectStateController).AsSingle();
            Container.Bind<SceneController>().FromInstance(sceneController).AsSingle();
            Container.Bind<ProjectPanelsManager>().FromInstance(projectPanelsManager).AsSingle();
        }

        private void BindSound()
        {
            Container.Bind<SoundManager>().FromInstance(soundManager).AsSingle();
            Container.Bind<MusicManager>().FromInstance(musicManager).AsSingle();
        }
    }
}