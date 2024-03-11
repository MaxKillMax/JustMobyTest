using JMT.Assets;
using JMT.Items;
using NaughtyAttributes;
using UnityEngine;

namespace JMT.Products
{
    [CreateAssetMenu(fileName = nameof(ProductData), menuName = nameof(ProductData), order = 51)]
    public class ProductData : ScriptableObject
    {
        [ShowAssetPreview, SerializeField] private Sprite _icon;

        [BoxGroup("Info"), SerializeField] private string _name;
        [BoxGroup("Info"), SerializeField, TextArea] private string _description;

        [BoxGroup("Reward"), SerializeField] private ItemDataCollection[] _items;

        [BoxGroup("Price"), SerializeField] private float _price;
        [BoxGroup("Price"), SerializeField] private bool _hasDiscount;
        [BoxGroup("Price"), SerializeField, ShowIf(nameof(_hasDiscount))] private float _discountPrice;

        public string Name => _name;
        public string Description => _description;

        public Sprite Icon => _icon;

        public ItemDataCollection[] Items => _items;

        public float Price => _price;
        public bool HasDiscount => _hasDiscount;
        public float DiscountPrice => _discountPrice;

#if UNITY_EDITOR
        private void OnValidate()
        {
            AssetRenamer.Rename(this, _name);
        }
#endif
    }
}
