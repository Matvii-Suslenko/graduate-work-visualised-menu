using UnityEngine;
using Models;

namespace Views.StartScreenView
{
    public class StartScreenPresenter : Presenter<IStartScreenView>
    {
        [SerializeField]
        private OrderModel _orderModel;
        
        protected override void Awake()
        {
            base.Awake();
            View.StartOrderClicked += OnStartOrderClicked;
        }

        private void OnStartOrderClicked()
        {
            _orderModel.ClearOrder();
            _viewManager.OpenView(ViewName.Menu);
        }

        private void OnDestroy()
        {
            View.StartOrderClicked -= OnStartOrderClicked;
        }
    }
}
