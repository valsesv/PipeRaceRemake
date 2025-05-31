using System;
using UnityEngine;
using UnityEngine.UI;

namespace valsesv._Project.Scripts.UI.ProjectPanels
{
    public class ConfirmPanel : UiPanel
    {
        [SerializeField] private Button confirmButton;
        public event Action OnConfirmed;

        protected override void Start()
        {
            base.Start();
            confirmButton.onClick.AddListener(() =>
            {
                OnConfirmed?.Invoke();
                CloseWindow();
            });
        }

        public override void CloseWindow()
        {
            base.CloseWindow();
            OnConfirmed = null;
        }
    }
}