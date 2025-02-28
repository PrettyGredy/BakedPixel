using System;
using System.Collections.Generic;
using Inventory.Item;
using Inventory.Item.ItemSO;
using Saver;

namespace Inventory.InventoryLoadStrategy
{
    public class SaveLoadInventoryStrategy: IInventoryLoadStrategy
    {
        private List<InventoryItemSO> _itemsSO;
        private InventoryDataSave _inventoryDataSave;
        private int _inventoryCapacity;

        public SaveLoadInventoryStrategy(List<InventoryItemSO> itemsSO, InventoryDataSave inventoryDataSave, int inventoryCapacity)
        {
            _itemsSO = itemsSO;
            _inventoryDataSave = inventoryDataSave;
            _inventoryCapacity = inventoryCapacity;
        }
        
        public InventoryData LoadInventory()
        {
            InventoryData newData = new InventoryData(_inventoryCapacity);
            
            
            for (int i = 0; i < _inventoryDataSave.Items.Count; i++)
            {
                var itemSave = _inventoryDataSave.Items[i];
                
                int index = itemSave.Type;
                Array enumValues = ItemType.GetValues(typeof(ItemType));
                ItemType enumValue = (ItemType)enumValues.GetValue(index);
                
                var temp = InventoryItemFactory.Instance.Create(enumValue, itemSave.StackSize);
                if (temp != null)
                {
                    newData.AddItem(temp);
                }
            }
            
            return newData;
        }
    }
}