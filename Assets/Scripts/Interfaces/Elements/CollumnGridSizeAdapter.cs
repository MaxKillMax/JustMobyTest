using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace JMT.Interfaces.Elements
{
    [RequireComponent(typeof(GridLayoutGroup)), DisallowMultipleComponent]
    public class CollumnGridSizeAdapter : MonoBehaviour
    {
        [SerializeField, ReadOnly] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField, ReadOnly] private RectTransform _rectTransform;

        [SerializeField] private float _heightToWidthRatio = 1;
        [SerializeField] private bool _isWaitForResizing = false;

        private float _width;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_gridLayoutGroup)
                _gridLayoutGroup = GetComponent<GridLayoutGroup>();

            if (_gridLayoutGroup.constraint != GridLayoutGroup.Constraint.FixedColumnCount)
                _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;

            if (!_rectTransform)
                _rectTransform = GetComponent<RectTransform>();
        }
#endif

        private void Awake()
        {
            UpdateWidth();

            if (!_isWaitForResizing)
            {
                Adapt();
                return;
            }

            Times.Time.OnUpdate += CheckResizing;
        }

        private void CheckResizing()
        {
            if (_width == _rectTransform.rect.width)
                return;

            Times.Time.OnUpdate -= CheckResizing;
            Adapt();
        }

        [Button("Adapt")]
        private void Adapt()
        {
            UpdateWidth();

            float totalSpacing = _gridLayoutGroup.spacing.x * (_gridLayoutGroup.constraintCount - 1);
            float cellWidth = (_width - totalSpacing) / _gridLayoutGroup.constraintCount;
            float cellHeight = cellWidth / _heightToWidthRatio;

            _gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
        }

        private void UpdateWidth() => _width = _rectTransform.rect.width + Mathf.Abs(_rectTransform.offsetMin.x) + Mathf.Abs(_rectTransform.offsetMax.x);
    }
}
