using UnityEngine;
using valsesv._Project.Scripts.UI.GamePanels;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameScene
{
    public class GameSceneManager : MonoBehaviour
    {
        [Inject] private GamePanelsManager _gamePanelsManager;

        private void OnDestroy()
        {
            ContinueGame();
        }

        public static void PauseGameByUIWindow(bool isPaused)
        {
            if (isPaused)
            {
                StopGame();
                return;
            }
            ContinueGame();
        }

        public void FinishGameInstantly()
        {
            FinishGame();
            _gamePanelsManager.OpenPanel(GamePanelType.GameOver);
        }

        private static void StopGame()
        {
            Time.timeScale = 0f;
        }

        private static void ContinueGame()
        {
            Time.timeScale = 1f;
        }

        private void FinishGame()
        {
        }
    }
}