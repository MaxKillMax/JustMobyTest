using JMT.Assets;
using NaughtyAttributes;
using UnityEngine;

namespace JMT.Items
{
    [CreateAssetMenu(fileName = nameof(ItemData), menuName = nameof(ItemData), order = 51)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _name;
        [ShowAssetPreview, SerializeField] private Sprite _icon;

        public string Name => _name;
        public Sprite Icon => _icon;

#if UNITY_EDITOR
        private void OnValidate()
        {
            AssetRenamer.Rename(this, _name);
        }
#endif
    }
}
