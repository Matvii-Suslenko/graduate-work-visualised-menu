using UnityEngine.UI;
using UnityEngine;
using Models;

namespace Views.FinishScreenView
{
    public class FinishScreenPresenter : Presenter<IFinishScreenView>
    {
        [SerializeField]
        private OrderModel _orderModel;
        
        protected override void Awake()
        {
            base.Awake();

            View.StartNewOrderClicked += OnStartNewOrderClicked;
            _orderModel.NewOrderReceived += OnNewOrderReceived;
        }

        private void OnNewOrderReceived(int newOrderId)
        {
            View.SetOrderId(newOrderId);
        }

        private void OnStartNewOrderClicked()
        {
            _orderModel.ClearOrder();
            _viewManager.OpenView(ViewName.StartScreen);
        }

        private void OnDestroy()
        {
            View.StartNewOrderClicked -= OnStartNewOrderClicked;
            _orderModel.NewOrderReceived += OnNewOrderReceived;
        }
    }
}
