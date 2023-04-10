using System.Collections.Generic;
using UnityEngine;
using Views;

public class ViewManager : MonoBehaviour, IViewManager
{
    [SerializeField]
    private List<BaseView> _views;
    
    public void OpenView(ViewName viewName)
    {
        foreach (var view in _views)
        {
            if (view.ViewName == viewName)
            {
                view.SetInteractable(true);
                view.ReceiveFocus();
            }
            else
            {
                view.SetInteractable(false);
            }
        }
    }
}
