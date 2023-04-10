using UnityEngine.UI;
using UnityEngine;
using System;

namespace Views.FinishScreenView
{
    public class FinishScreenView : BaseView, IFinishScreenView
    {
        public event Action StartNewOrderClicked;

        public override ViewName ViewName => ViewName.FinishScreen;

        [SerializeField]
        private Button _startNewOrderButton;

        private void Awake()
        {
            _startNewOrderButton.onClick.AddListener(OnStartNewOrderClicked);
        }

        private void OnStartNewOrderClicked() => StartNewOrderClicked?.Invoke();

        private void OnDestroy()
        {
            _startNewOrderButton.onClick.RemoveListener(OnStartNewOrderClicked);
        }
    }
}
