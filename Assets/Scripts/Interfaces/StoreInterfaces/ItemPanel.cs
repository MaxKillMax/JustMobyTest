using JMT.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JMT.Interfaces.StoreInterfaces
{
    public class ItemPanel : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _countText;

        private ItemDataCollection _itemDataCollection;

        public void SetState(bool state) => gameObject.SetActive(state);

        public void SetItem(ItemDataCollection itemDataCollection)
        {
            _itemDataCollection = itemDataCollection;

            _icon.sprite = _itemDataCollection.ItemData.Icon;
            _countText.text = itemDataCollection.Count.ToString();
        }
    }
}