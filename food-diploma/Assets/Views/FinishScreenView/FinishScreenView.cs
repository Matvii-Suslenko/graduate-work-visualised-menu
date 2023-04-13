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
        
        [SerializeField]
        private Text _orderIdText;

        private void Awake()
        {
            _startNewOrderButton.onClick.AddListener(OnStartNewOrderClicked);
        }
        
        public void SetOrderId(int id)
        {
            _orderIdText.text = $"#{id}";
        }
        
        public override void SetInteractable(bool isInteractable)
        {
            base.SetInteractable(isInteractable);

            if (!isInteractable)
            {
                _orderIdText.text = string.Empty;
            }
        }

        private void OnStartNewOrderClicked() => StartNewOrderClicked?.Invoke();

        private void OnDestroy()
        {
            _startNewOrderButton.onClick.RemoveListener(OnStartNewOrderClicked);
        }
    }
}
