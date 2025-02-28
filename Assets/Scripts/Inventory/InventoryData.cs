using System.Collections.Generic;
using Inventory.Item;

namespace Inventory
{
    public class InventoryData
    {
        private List<InventoryItem> _items;
        private int _inventoryСapacity;
        public IReadOnlyList<InventoryItem> Items => _items;
        public int InventoryСapacity => _inventoryСapacity;

        public InventoryData(int inventoryCapacity)
        {
            _items = new List<InventoryItem>();
            _inventoryСapacity = inventoryCapacity;
        }

        public void AddItem(InventoryItem newItem)
        {
            foreach (var item in _items)
            {
                if (item.Type == newItem.Type && !item.IsFullStack)
                {
                    item.AddInStack();
                    return;
                }
            }
            
            if(_items.Count < _inventoryСapacity) _items.Add(newItem);
        }
        
        public void AddFullStackItem(InventoryItem newItem)
        {
            if(_items.Count < _inventoryСapacity) _items.Add(newItem);
        }

        public void RemoveItem(InventoryItem removeItem)
        {
            foreach (var item in _items)
            {
                if (item == removeItem && !item.IsEmptyStack)
                {
                    item.RemoveInStack();
                    return;
                }
            }
            
            _items.Remove(removeItem);
        }
        
        public void RemoveFullStackItem(InventoryItem removeItem)
        {
            _items.Remove(removeItem);
        }

        public void Swap(InventoryItem itemM, InventoryItem itemN)
        {
            int indexM = _items.IndexOf(itemM);
            int indexN = _items.IndexOf(itemN);

            if (indexM == -1) return;

            if (indexN == -1)
            {
                _items.RemoveAt(indexM);
                _items.Add(itemM);
            }
            else
            {
                (_items[indexM], _items[indexN]) = (_items[indexN], _items[indexM]);
            }
        }
    }
}