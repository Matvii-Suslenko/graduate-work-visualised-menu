namespace Views
{
    public interface IView
    {
        /// <summary>
        /// ViewName
        /// </summary>
        ViewName ViewName { get; }
        
        /// <summary>
        /// Sets Interactable
        /// </summary>
        /// <param name="isInteractable">True if Interactable</param>
        void SetInteractable(bool isInteractable);
    }
}