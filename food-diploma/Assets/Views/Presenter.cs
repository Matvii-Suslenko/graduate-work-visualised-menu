using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(IView))]
    public class Presenter<T> : MonoBehaviour where T : IView
    {
        [SerializeField]
        protected ViewManager _viewManager;
        
        protected T View;

        protected virtual void Awake()
        {
            View = GetComponent<T>();
        }
    }
}
