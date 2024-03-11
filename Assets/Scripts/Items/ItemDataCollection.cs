using System;
using UnityEngine;

namespace JMT.Items
{
    [Serializable]
    public struct ItemDataCollection
    {
        [SerializeField] public ItemData ItemData;
        [SerializeField] public int Count;
    }
}
