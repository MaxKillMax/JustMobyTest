using System.Collections.Generic;
using JMT.Interfaces.MessageInterfaces;
using JMT.Products;
using UnityEngine;
using UnityEngine.UI;

namespace JMT.Interfaces.StoreInterfaces
{
    public sealed class StoreInterface : Interface
    {
        [SerializeField] private ProductDataCollection _productDataCollection;

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundCloseButton;
        [SerializeField] private Transform _productParent;
        [SerializeField] private ProductPanel _productPrefab;

        [SerializeField] private int _showingProductsCount;

        private readonly List<ProductPanel> _productPanels = new List<ProductPanel>();

        public int ShowingProductsCount { set => _showingProductsCount = value; }

        protected override void OnInitialized()
        {
            _closeButton.onClick.AddListener(CloseSelf);
            _backgroundCloseButton.onClick.AddListener(CloseSelf);

            void CloseSelf() => Close(this);
        }

        protected override void Enable()
        {
            for (int i = 0; i < _showingProductsCount; i++)
                CreateProductPanel(i);

            void CreateProductPanel(int i)
            {
                if (_productDataCollection.Length <= i)
                    return;

                ProductPanel productPanel = Instantiate(_productPrefab, _productParent);
                productPanel.Initialize(_productDataCollection.ProductDatas[i]);
                productPanel.OnClick += () => OnProductClick(productPanel);
                _productPanels.Add(productPanel);
            }
        }

        protected override void Disable()
        {
            for (int i = 0; i < _productPanels.Count; i++)
                Destroy(_productPanels[i].gameObject);

            _productPanels.Clear();
        }

        private void OnProductClick(ProductPanel productPanel)
        {
            Close(this);

            string message = $"Продукт \"{productPanel.Data.Name}\" успешно куплен!";

            Debug.Log(message);
            MessageInterface.Show(message);
        }
    }
}