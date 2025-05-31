using System.Collections;
using TMPro;
using UnityEngine;

namespace valsesv._Project.Scripts.UI
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI popUpText;
        [SerializeField] private float popUpDuration = 2f;

        private Coroutine _popUpCoroutine;

        private void Start()
        {
            canvasGroup.alpha = 0f;
        }

        public void ShowPopUp(string text)
        {
            popUpText.text = text;
            CanvasSwapper.CanvasGroupSwap(canvasGroup, true);

            if (_popUpCoroutine != null)
                StopCoroutine(_popUpCoroutine);

            _popUpCoroutine = StartCoroutine(HidePopUp());
        }

        private IEnumerator HidePopUp()
        {
            yield return new WaitForSeconds(popUpDuration);
            CanvasSwapper.CanvasGroupSwap(canvasGroup, false);
        }
    }
}