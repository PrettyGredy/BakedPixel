using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Item.Command
{
    public class DeleteItemCommand: ICommand
    {
        private InventoryManager _inventoryManager;
        private InventoryData _data;
        
        public DeleteItemCommand(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
            _data = _inventoryManager.Data;
        }
        
        public void Execute()
        {
            if (_data.Items.Count <= 0)
            {
                Debug.LogError("There are no items to delete!");
                return;
            }
            
            List<InventoryItem> filteredItems = _data.Items?
                .Where(item => item.Type == ItemType.HeadCap || 
                               item.Type == ItemType.HeadHelmet ||
                               item.Type == ItemType.TorsoBulletproof ||
                               item.Type == ItemType.TorsoJacket ||
                               item.Type == ItemType.WeaponPistol ||
                               item.Type == ItemType.WeaponRifle)
                .ToList();

            if (filteredItems.Count <= 0)
            {
                Debug.LogError("There are no items to delete!");
                return;
            }
            
            int index = Random.Range(0, filteredItems.Count);
            _data.RemoveFullStackItem(filteredItems[index]);

            _inventoryManager.OnInventoryChanged?.Invoke();
        }
    }
}