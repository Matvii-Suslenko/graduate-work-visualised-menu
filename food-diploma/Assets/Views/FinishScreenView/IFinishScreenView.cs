using System;

namespace Views.FinishScreenView
{
    public interface IFinishScreenView : IView
    {
        /// <summary>
        /// Fires when Start New Order Button is Clicked
        /// </summary>
        event Action StartNewOrderClicked;
    }
}