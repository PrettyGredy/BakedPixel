using System;
using Inventory.InventoryLoadStrategy;

namespace Inventory
{
    public class InventoryManager
    {
        private IInventoryLoadStrategy _loadStrategy;
        private InventoryData _data;

        public InventoryData Data => _data;
        public Action OnInventoryChanged;
        
        public void Init(IInventoryLoadStrategy loadStrategy)
        {
            _loadStrategy = loadStrategy;
            _data = _loadStrategy.LoadInventory();
        }
    }
}