using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JMT.Interfaces.StoreInterfaces
{
    [RequireComponent(typeof(Button))]
    public class ProductBuyButton : MonoBehaviour
    {
        [SerializeField, ReadOnly] private Button _button;

        [SerializeField] private GameObject _defaultPanel;
        [SerializeField] private GameObject _discountPanel;

        [SerializeField] private TMP_Text _defaultPriceText;

        [SerializeField] private TMP_Text _discountPriceText;
        [SerializeField] private TMP_Text _noDiscountPriceText;

        [SerializeField] private TMP_Text _discountText;

        public event Action OnClick;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_button)
                _button = GetComponent<Button>();
        }
#endif

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick() => OnClick?.Invoke();

        public void SetDefaultPrice(float price)
        {
            _defaultPriceText.text = GetPriceText(price);

            SetDefaultState(true);
        }

        public void SetDiscontPrice(float price, float noDiscountPrice)
        {
            _discountPriceText.text = GetPriceText(price);
            _noDiscountPriceText.text = GetPriceText(noDiscountPrice);
            _discountText.text = GetDiscountText(price / noDiscountPrice);

            SetDefaultState(false);
        }

        private void SetDefaultState(bool state)
        {
            _defaultPanel.SetActive(state);
            _discountPanel.SetActive(!state);
        }

        private string GetPriceText(float price) => '$' + price.ToString("N2");

        private string GetDiscountText(float relation) => Mathf.RoundToInt((1 - relation) * 100).ToString() + '%';
    }
}