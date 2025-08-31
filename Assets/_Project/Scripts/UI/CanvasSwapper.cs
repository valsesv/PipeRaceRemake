using DG.Tweening;
using UnityEngine;

namespace valsesv._Project.Scripts.UI
{
    public static class CanvasSwapper
    {
        public const float SwapDuration = 0.25f;

        public static void CanvasGroupSwap(CanvasGroup canvasGroup, bool isEnabled)
        {
            canvasGroup.DOFade(isEnabled? 1 : 0, SwapDuration).SetUpdate(true);

            canvasGroup.interactable = isEnabled;
            canvasGroup.blocksRaycasts = isEnabled;
        }
    }
}