using UnityEngine;

namespace Views
{
    public class BaseView : MonoBehaviour, IView
    {
        public virtual ViewName ViewName { get; }
        
        [SerializeField]
        private GameObject _viewRoot;

        public virtual void SetInteractable(bool isInteractable)
        {
            _viewRoot.SetActive(isInteractable);
        }

        public virtual void ReceiveFocus()
        {
        }
    }
}

