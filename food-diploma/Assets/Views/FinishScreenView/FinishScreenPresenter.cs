using UnityEngine;
using Models;

namespace Views.FinishScreenView
{
    public class FinishScreenPresenter : Presenter<FinishScreenView>
    {
        [SerializeField]
        private OrderModel _orderModel;
        
        protected override void Awake()
        {
            base.Awake();
            View.StartNewOrderClicked += OnStartNewOrderClicked;
        }

        private void OnStartNewOrderClicked()
        {
            _orderModel.ClearOrder();
            _viewManager.OpenView(ViewName.StartScreen);
        }

        private void OnDestroy()
        {
            View.StartNewOrderClicked -= OnStartNewOrderClicked;
        }
    }
}
