using UnityEngine.UI;
using UnityEngine;

public class OrderBehaviour : MonoBehaviour
{
    [SerializeField] private Button _closeOrderButton;
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _orderText;

    private void Awake()
    {
        _closeOrderButton.onClick.AddListener(OnCloseClicked);
    }

    private void OnCloseClicked()
    {
        Destroy(gameObject);
    }

    public void SetOrderInfo(int orderId, string orderString)
    {
        _titleText.text = $"Order #{orderId}";
        _orderText.text = orderString;
    }

    private void OnDestroy()
    {
        _closeOrderButton.onClick.RemoveListener(OnCloseClicked);
    }
}
