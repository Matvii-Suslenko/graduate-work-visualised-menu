using UnityEngine;
using Views;

public class Bootstraper : MonoBehaviour
{
    [SerializeField]
    private ViewManager _viewManager;
    
    private void Start()
    {
        _viewManager.OpenView(ViewName.StartScreen);
    }
}
