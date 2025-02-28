using System.Collections.Generic;

namespace Inventory.Item.Command
{
    public class AddAmmoCommand: ICommand
    {
        private InventoryManager _inventoryManager;
        private InventoryData _data;
        
        public AddAmmoCommand(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
            _data = _inventoryManager.Data;
        }
        
        public void Execute()
        {
            List<ItemType> poolTypes = new List<ItemType>();

            poolTypes.Add(ItemType.AmmoPistol);
            poolTypes.Add(ItemType.AmmoRifle);

            foreach (var type in poolTypes)
            {
                var temp = InventoryItemFactory.Instance.Create(type);
                if (temp != null)
                {
                    _data.AddFullStackItem(temp);
                }
            }
            
            _inventoryManager.OnInventoryChanged?.Invoke();
        }
    }
}