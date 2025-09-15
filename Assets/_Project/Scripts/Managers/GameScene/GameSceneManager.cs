using UnityEngine;
using valsesv._Project.Scripts.UI.GamePanels;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameScene
{
    public class GameSceneManager : MonoBehaviour
    {
        [Inject] private GamePanelsManager _gamePanelsManager;

        public bool IsWin { get; private set; } = false;

        public static void PauseGameByUIWindow(bool isPaused)
        {
            if (isPaused)
            {
                StopGame();
                return;
            }
            ContinueGame();
        }

        public void WinGame()
        {
            IsWin = true;
            FinishGame();
        }

        public void LoseGame()
        {
            IsWin = false;
            FinishGame();
        }

        public void FinishGameInstantly()
        {
            FinishGame();
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
            StopGame();
            _gamePanelsManager.OpenPanel(GamePanelType.GameOver);
        }
    }
}