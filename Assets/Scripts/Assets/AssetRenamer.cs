using UnityEditor;
using UnityEngine;

namespace JMT.Assets
{
#if UNITY_EDITOR
    public static class AssetRenamer
    {
        private const string ASSET_EXTENSION = ".asset";
        private const string DEFAULT_ASSET_NAME = "Data";

        public static void Rename(Object @object, string name)
        {
            if (string.IsNullOrEmpty(name))
                name = DEFAULT_ASSET_NAME;

            string path = AssetDatabase.GetAssetPath(@object.GetInstanceID());
            string assetName = name + ASSET_EXTENSION;

            if (!path.Contains(assetName))
                AssetDatabase.RenameAsset(path, assetName);
        }
    }
#endif
}