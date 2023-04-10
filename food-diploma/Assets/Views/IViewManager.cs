namespace Views
{
    public interface IViewManager
    {
        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="viewName">View Name</param>
        void OpenView(ViewName viewName);
    }
}
