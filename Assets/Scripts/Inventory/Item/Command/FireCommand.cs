using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Item.Command
{
    public class FireCommand: ICommand
    {
        private InventoryManager _inventoryManager;
        private InventoryData _data;
        
        public FireCommand(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
            _data = _inventoryManager.Data;
        }
        
        public void Execute()
        {
            if (_data.Items.Count <= 0)
            {
                return;
            }

            List<InventoryItem> filteredItems = _data.Items?
                .Where(item => item.Type == ItemType.AmmoPistol || item.Type == ItemType.AmmoRifle)
                .ToList();

            if (filteredItems == null || filteredItems.Count == 0)
            {
                return;
            }

            int index = Random.Range(0, filteredItems.Count);
            _data.RemoveItem(filteredItems[index]);
            
            _inventoryManager.OnInventoryChanged?.Invoke();        
        }
    }
}