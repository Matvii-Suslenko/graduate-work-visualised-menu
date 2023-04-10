using UnityEngine.UI;
using UnityEngine;
using System;

namespace Views.StartScreenView
{
    public class StartScreenView : BaseView, IStartScreenView
    {
        public event Action StartOrderClicked;

        public override ViewName ViewName => ViewName.StartScreen;

        [SerializeField]
        private Button _startOrderButton;

        private void Awake()
        {
            _startOrderButton.onClick.AddListener(OnStartOrderClicked);
        }

        private void OnStartOrderClicked() => StartOrderClicked?.Invoke();

        private void OnDestroy()
        {
            _startOrderButton.onClick.RemoveListener(OnStartOrderClicked);
        }
    }
}
