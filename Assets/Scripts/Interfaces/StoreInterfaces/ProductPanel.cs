using System;
using System.Collections.Generic;
using JMT.Products;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace JMT.Interfaces.StoreInterfaces
{
    public class ProductPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;

        [Space]

        [SerializeField] private Image _icon;
        [SerializeField] private ProductBuyButton _buyButton;

        [Space]

        [SerializeField] private List<ItemPanel> _items;

        public ProductData Data { get; private set; }

        public event Action OnClick;

        public void Initialize(ProductData productData)
        {
            Assert.IsNull(Data);

            Data = productData;

            _title.text = Data.Name;
            _description.text = Data.Description;
            _icon.sprite = Data.Icon;

            _buyButton.OnClick += OnButtonClick;

            SetPrice();
            InitializeItemPanels();
        }

        private void OnButtonClick() => OnClick?.Invoke();

        private void SetPrice()
        {
            if (Data.HasDiscount)
                _buyButton.SetDiscontPrice(Data.DiscountPrice, Data.Price);
            else
                _buyButton.SetDefaultPrice(Data.Price);
        }

        private void InitializeItemPanels()
        {
            for (int i = 0; i < _items.Count; i++)
                InitializeItemPanel(i);
        }

        private void InitializeItemPanel(int i)
        {
            bool state = Data.Items.Length > i;
            _items[i].SetState(state);

            if (state)
                _items[i].SetItem(Data.Items[i]);
        }
    }
}