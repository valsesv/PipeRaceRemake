using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using valsesv._Project.Scripts.Interfaces;
using valsesv._Project.Scripts.UI;

namespace valsesv._Project.Scripts.Managers.ScenesManagement
{
    public class SceneController : MonoBehaviour, IManager
    {
        [SerializeField] private SceneType scenesTypeInfo;
        [SerializeField] private CanvasGroup loadingScreen;
        [SerializeField] private float minLoadingTime = 1f;

        private const int SleepDelay = (int)(CanvasSwapper.SwapDuration * 1000);

        public void Init()
        {
            loadingScreen.alpha = 1f;
        }

        public async void LoadScene(SceneType sceneType)
        {
            CanvasSwapper.CanvasGroupSwap(loadingScreen, true);
            await Task.Delay(SleepDelay);
            Time.timeScale = 1f;

            var operation = SceneManager.LoadSceneAsync((int) sceneType);
            var startLoadingTime = Time.unscaledTime;

            while (operation.isDone == false || Time.unscaledTime - startLoadingTime < minLoadingTime)
            {
                await Task.Delay(SleepDelay);
            }

            CanvasSwapper.CanvasGroupSwap(loadingScreen, false);
        }
    }
}