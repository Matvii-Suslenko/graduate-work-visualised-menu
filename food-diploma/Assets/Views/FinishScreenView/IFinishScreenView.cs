using System;

namespace Views.FinishScreenView
{
    public interface IFinishScreenView : IView
    {
        /// <summary>
        /// Fires when Start New Order Button is Clicked
        /// </summary>
        event Action StartNewOrderClicked;

        /// <summary>
        /// Sets Order Id
        /// </summary>
        /// <param name="id">Order Id</param>
        void SetOrderId(int id);
    }
}