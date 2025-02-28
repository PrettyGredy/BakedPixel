using Inventory.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Cell
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _countText;
        [SerializeField] private Image _lock;
        [SerializeField] private CellState _state;

        private ItemType _itemType;
        private InventoryItem _inventoryItem;

        public ItemType ItemType => _itemType;
        public InventoryItem InventoryItem => _inventoryItem;
        public CellState State => _state;

        public void SetLock()
        {
            _lock.gameObject.SetActive(true);
            _state = CellState.Lock;
        }

        public void Draw(InventoryItem item)
        {
            _icon.gameObject.SetActive(true);
            _icon.sprite = item.Icon;
            _itemType = item.Type;
            _inventoryItem = item;
            _state = CellState.Busy;

            if (item.CurrentStackSize <= 1)
            {
                _countText.gameObject.SetActive(false);
            }
            else
            {
                _countText.gameObject.SetActive(true);
                _countText.text = "x" + item.CurrentStackSize.ToString();
            }
        }

        public void ClearCell()
        {
            _icon.sprite = null;
            _icon.gameObject.SetActive(false);
            _countText.text = "";
            _countText.gameObject.SetActive(false);

            if (_state == CellState.Busy)
            {
                _state = CellState.Free;
            }
        }
    }
}