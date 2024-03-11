using System;
using JMT.Interfaces.StoreInterfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JMT.Interfaces.MenuInterfaces
{
    public sealed class MenuInterface : Interface
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _storeButton;

        protected override void OnInitialized()
        {
            SetState(true);

            _storeButton.onClick.AddListener(OnButtonClick);
            _inputField.onEndEdit.AddListener(OnInputFieldChanged);
        }

        private void OnButtonClick() => Additive<StoreInterface>();

        private void OnInputFieldChanged(string value) => Get<StoreInterface>().ShowingProductsCount = Convert.ToInt32(value);
    }
}