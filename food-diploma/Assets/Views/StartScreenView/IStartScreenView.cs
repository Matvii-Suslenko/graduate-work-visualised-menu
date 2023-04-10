using System;

namespace Views.StartScreenView
{
    public interface IStartScreenView : IView
    {
        /// <summary>
        /// Fires when Start Order Button is Clicked
        /// </summary>
        event Action StartOrderClicked;
    }
}