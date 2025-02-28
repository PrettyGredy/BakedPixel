using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Inventory.Item.Command
{
    public class AddItemCommand: ICommand
    {
        private InventoryManager _inventoryManager;
        private InventoryData _data;
        
        public AddItemCommand(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
            _data = _inventoryManager.Data;
        }
        
        public void Execute()
        {
            List<ItemType> poolTypes = new List<ItemType>();

            poolTypes.Add(GetRand(ItemType.HeadCap, ItemType.HeadHelmet));
            poolTypes.Add(GetRand(ItemType.TorsoJacket, ItemType.TorsoBulletproof));
            poolTypes.Add(GetRand(ItemType.WeaponPistol, ItemType.WeaponRifle));
            
            foreach (var type in poolTypes)
            {
                var temp = InventoryItemFactory.Instance.Create(type);
                if (temp != null)
                {
                    _data.AddItem(temp);
                }
            }
            
            _inventoryManager.OnInventoryChanged?.Invoke();
        }

        private ItemType GetRand(ItemType r1, ItemType r2)
        {
            int index = Random.Range(0, 2);

            if (index == 1)
            {
                return r2;
            }

            return r1;
        }
    }
}