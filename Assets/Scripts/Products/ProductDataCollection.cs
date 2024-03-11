using UnityEngine;

namespace JMT.Products
{
    [CreateAssetMenu(fileName = nameof(ProductDataCollection), menuName = nameof(ProductDataCollection), order = 51)]
    public class ProductDataCollection : ScriptableObject
    {
        [SerializeField] private ProductData[] _productDatas;

        public ProductData[] ProductDatas => _productDatas;
        public int Length => _productDatas.Length;
    }
}
